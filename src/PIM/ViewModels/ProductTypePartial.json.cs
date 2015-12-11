using Starcounter;

namespace PIM.ViewModels {

    partial class ProductTypePartial : Page, IBound<ProductType> {
        public string UriBinding {
            get {
                var t = this.Data;
                return string.Format("/pim/types/{0}", t.GetObjectID());
            }
        }
    }

    [ProductTypePartial_json.ParentType]
    partial class ProductTypeParent : Page, IBound<ProductType> {
        public string UriBinding {
            get {
                var t = this.Parent.Data as ProductType;
                t = t.ParentType;
                if (t == null) {
                    return "";
                }

                return string.Format("/pim/types/{0}", t.GetObjectID());
            }
        }
    }
}
