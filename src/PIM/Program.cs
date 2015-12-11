using System;
using Starcounter;
using PIM.ViewModels;

namespace PIM {

    class Program {

        static void Main() {
            SampleData();

            Handle.GET("/PIM/menu", () => {
                return new Page() { Html = "/PIM/AppMenuPartial.html" };
            });

            UriMapping.Map("/PIM/menu", UriMapping.MappingUriPrefix + "/menu");

            Handle.GET("/PIM/app-name", () => {
                return new AppNamePartial();
            });

            UriMapping.Map("/PIM/app-name", UriMapping.MappingUriPrefix + "/app-name");

            Handle.GET("/pim/types/{?}", (string id) => {
                var oid = DbHelper.Base64DecodeObjectID(id);
                var type = DbHelper.FromID(oid) as ProductType;

                if (type == null) {
                    return 404;
                }
                
                return new ProductTypePartial() { Data = type };
            });

            Handle.GET("/pim/types", () => {
                var p = new ProductTypeList();
                p.Init();
                return p;
            });
        }

        static void SampleData() {
            var type = Db.SQL<ProductType>("SELECT p FROM ProductType p").First;
            if (type != null) return;

            Db.Transact(() => {
                var os = new ProductType() {
                    Id = "OperatingSystem",
                    Name = "Operating systems",
                    Description = "Operating systems such as Android, Windows and Linux"
                };

                var win = new ProductType() {
                    Id = "Windows",
                    Name = "Windows",
                    Description = "The Windows operating system",
                    ParentType = os
                };

                var win10 = new ProductType() {
                    Id = "Windows10",
                    Name = "Windows 10",
                    Description = "The Windows 10 operating system",
                    ParentType = win
                };

                var ubuntu = new ProductType() {
                    Id = "Ubuntu",
                    Name = "Ubuntu",
                    Description = "The Ubuntu operating system",
                    ParentType = os
                };
            });
        }
    }
}