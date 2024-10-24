using Microsoft.JSInterop;

namespace Student_Support_System.Utility
{
    public class StartJavaScriptDefault
    {
        public static async Task StartJavaScript(IJSRuntime jSRuntime)
        {
            // Call the JavaScript function to load the script
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/global/global.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./js/quixnav-init.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/raphael/raphael.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/circle-progress/circle-progress.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/chart.js/Chart.bundle.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/gaugeJS/dist/gauge.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/flot/jquery.flot.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/flot/jquery.flot.resize.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/owl-carousel/js/owl.carousel.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/jqvmap/js/jquery.vmap.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/jqvmap/js/jquery.vmap.usa.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/jquery.counterup/jquery.counterup.min.js");
            //await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/datatables/js/jquery.dataTables.min.js");
            //await jSRuntime.InvokeVoidAsync("loadScript", "./js/plugins-init/datatables.init.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./vendor/select2/js/select2.full.min.js");
            await jSRuntime.InvokeVoidAsync("loadScript", "./js/plugins-init/select2-init.js");
        }
    }
}
