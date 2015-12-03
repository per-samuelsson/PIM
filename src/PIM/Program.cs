using System;
using Starcounter;

namespace PIM {
    class Program {
        static void Main() {
            Handle.GET("/PIM/menu", () => {
                return new Page() { Html = "/PIM/AppMenuPartial.html" };
            });

            UriMapping.Map("/PIM/menu", UriMapping.MappingUriPrefix + "/menu");

            Handle.GET("/PIM/app-name", () => {
                return new AppNamePartial();
            });

            UriMapping.Map("/PIM/app-name", UriMapping.MappingUriPrefix + "/app-name");
        }
    }
}