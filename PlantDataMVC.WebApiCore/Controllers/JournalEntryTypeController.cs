using AutoMapper;
using AutoMapper.QueryableExtensions;
using CacheCow.Server.Core.Mvc;
using DelegateDecompiler;
using Interfaces.Domain.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WebApiCore.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntryTypeController : ControllerBase
    {
        private const int MaxPageSize = 100;
        private readonly IJournalEntryTypeService _service;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public JournalEntryTypeController(IUnitOfWorkAsync unitOfWorkAsync,
                                          IJournalEntryTypeService service)
        {
            _service = service;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/JournalEntryType
        [HttpCacheFactory(300)]
        [HttpGet(Name = "JournalEntryTypeList")]
        //[Authorize(Policy = AuthorizationPolicies.RequireReadUserRole)]
        public IActionResult Get(
            string sort = "id",
            int page = 1, 
            int pageSize = MaxPageSize,
            string? fields = null)
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
                    childDtosToInclude = DataShaping.GetIncludedObjectNames<JournalEntryTypeDto>(lstOfFields);
                }

                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                var context = _service.Queryable();

                var dtos = context
                           .ProjectTo<JournalEntryTypeDto>(null, childDtosToInclude.ToArray())
                           .ApplySort(sort);

                // HACK: use URL content to determine route used to get here
                // better solution is to add name to data tokens, as per following links
                // https://stackoverflow.com/questions/363211/how-can-i-get-the-route-name-in-controller-in-asp-net-mvc
                // https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/

                var paginationHeaders = PagingHelper.GetPaginationHeaders(
                    Url,
                    dtos.Count(),
                    "JournalEntryTypeList",
                    new
                    {
                        sort,
                        fields
                    },
                    page,
                    pageSize);

                foreach (var hdr in paginationHeaders)
                {
                    HttpContext.Response.Headers.Add(hdr);
                }

                var itemList = dtos
                               .Paginate(page, pageSize)
                               .ToList()
                               .Select(jetdto => DataShaping.CreateDataShapedObject(jetdto, lstOfFields));

                return Ok(itemList);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
