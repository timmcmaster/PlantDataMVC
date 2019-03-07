using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using CacheCow.Server.WebApi;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Service;
using PlantDataMVC.WebApi.Helpers;
using Thinktecture.IdentityModel.WebApi;

namespace PlantDataMVC.WebApi.Controllers
{
    // TODO: add write methods with admin authorization

    [RoutePrefix("api")]
    public class ProductTypeController : ApiController
    {
        private const int MaxPageSize = 100;
        private readonly IProductTypeService _service;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ProductTypeController(IUnitOfWorkAsync unitOfWorkAsync,
                                     IProductTypeService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Site
        [HttpCache(DefaultExpirySeconds = 300)]
        [HttpGet]
        [Route("ProductType", Name = "ProductTypeList")]
        [ResourceAuthorize("Read", "ProductType")]
        public IHttpActionResult Get(
            string sort = "id",
            int page = 1, int pageSize = MaxPageSize,
            string fields = null)
        {
            try
            {
                // TODO: Current state doesn't return children by default, can only get with "fields" option
                // need to determine expected behaviour

                var childDtosToInclude = new List<string>();
                var lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.Split(',').ToList();
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<ProductTypeDto>(lstOfFields);
                }

                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                var context = _service.Queryable();

                var dtos = context
                           .ProjectTo<ProductTypeDto>(null, childDtosToInclude.ToArray())
                           .ApplySort(sort);

                // HACK: use URL content to determine route used to get here
                // better solution is to add name to data tokens, as per following links
                // https://stackoverflow.com/questions/363211/how-can-i-get-the-route-name-in-controller-in-asp-net-mvc
                // https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Count(),
                    "ProductTypeList",
                    new
                    {
                        sort,
                        fields
                    },
                    page,
                    pageSize);

                HttpContext.Current.Response.Headers.Add(paginationHeaders);

                var itemList = dtos
                               .Paginate(page, pageSize)
                               .ToList()
                               .Select(prodtype => DataShaping.CreateDataShapedObject(prodtype, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}