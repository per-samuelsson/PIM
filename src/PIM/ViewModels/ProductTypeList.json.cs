using Starcounter;

namespace PIM.ViewModels {

    partial class ProductTypeList : Page {

        public void Init() {
            this.ProductTypes = Db.SQL<ProductType>("SELECT p FROM ProductType p");
        }
    }
}