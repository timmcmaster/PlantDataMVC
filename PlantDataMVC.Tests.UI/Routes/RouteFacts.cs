using FluentAssertions; 
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;
using PlantDataMVC.UI;

namespace PlantDataMVC.Tests.UI.Routes
{
    public class RouteFacts
    {
        [Fact]
        public void RouteWithControllerNoActionNoId()
        {
            // Arrange
            StubContext context = new StubContext("~/controller1");
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().NotBeNull();
            routeData.Values["controller"].Should().Be("controller1");
            routeData.Values["action"].Should().Be("Index");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [Fact]
        public void RouteWithControllerWithActionNoId()
        {
            // Arrange
            StubContext context = new StubContext("~/controller1/action2");
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().NotBeNull();
            routeData.Values["controller"].Should().Be("controller1");
            routeData.Values["action"].Should().Be("action2");
            routeData.Values["id"].Should().Be(UrlParameter.Optional);
        }

        [Fact]
        public void RouteWithControllerWithActionWithId()
        {
            // Arrange
            StubContext context = new StubContext("~/controller1/action2/id3");
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().NotBeNull();
            routeData.Values["controller"].Should().Be("controller1");
            routeData.Values["action"].Should().Be("action2");
            routeData.Values["id"].Should().Be("id3");
        }

        [Fact]
        public void RouteWithTooManySegments()
        {
            // Arrange
            StubContext context = new StubContext("~/a/b/c/d");
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().BeNull();
        }

        [Fact]
        public void RouteForEmbeddedResource()
        {
            // Arrange
            StubContext context = new StubContext("~/foo.axd/bar/baz/biff");
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().NotBeNull();
            routeData.RouteHandler.Should().BeAssignableTo<StopRoutingHandler>();
        }
    }
}