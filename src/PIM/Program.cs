using System;
using Starcounter;

namespace PIM {
    class Program {
        static void Main() {
            Handle.GET("/PIM/menu", () => {
                return new Page() { Html = "/PIM/AppMenuPartial.html" };
            });

            UriMapping.Map("/PIM/menu", UriMapping.MappingUriPrefix + "/menu");
        }
    }
}