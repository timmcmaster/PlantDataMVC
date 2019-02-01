using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using PlantDataMVC.Tests.UI.TestDoubles;
using PlantDataMVC.UI;
using Xunit;

namespace PlantDataMVC.Tests.UI.Routes
{
    public class RouteFacts
    {
        [Fact]
        public void RouteForEmbeddedResource()
        {
            // Arrange
            var context = new StubContext("~/foo.axd/bar/baz/biff");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().NotBeNull();
            routeData.RouteHandler.Should().BeAssignableTo<StopRoutingHandler>();
        }

        [Fact]
        public void RouteWithControllerNoActionNoId()
        {
            // Arrange
            var context = new StubContext("~/controller1");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(context);

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
            var context = new StubContext("~/controller1/action2");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(context);

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
            var context = new StubContext("~/controller1/action2/id3");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(context);

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
            var context = new StubContext("~/a/b/c/d");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var routeData = routes.GetRouteData(context);

            // Assert
            routeData.Should().BeNull();
        }
    }
}