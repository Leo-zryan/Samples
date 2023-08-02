该项目中使用了自定义的启动页，并且移除了默认的路由以实现自定义启动页的效果。

DefaultRouteRemovalPageRouteModelConvention类是一个实现了IPageRouteModelConvention接口的自定义类。它用于移除指定路由的默认路由。在这里，它被用来移除空路由（String.Empty）的默认路由。

在Startup.cs文件的ConfigureServices方法中，通过services.AddRazorPages来添加Razor Pages服务，并且通过options.Conventions来添加自定义约定。

options.Conventions.Add(new DefaultRouteRemovalPageRouteModelConvention(String.Empty))语句添加了DefaultRouteRemovalPageRouteModelConvention约定，用于移除空路由（即根目录）的默认路由。

options.Conventions.AddPageRoute("/Account/Login", "")语句指定了/Login路径作为新的默认路由。也就是说，当用户访问根目录时，会被重定向到/Account/Login页面。

通过以上配置，实现了自定义启动页的效果。用户在访问网站根目录时，将被导航到/Account/Login页面。注意，你需要确保/Account/Login路径指向存在的页面（在Pages文件夹下的Account文件夹下的Login.cshtml）。