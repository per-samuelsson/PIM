using Starcounter;

namespace PIM.ViewModels {

    partial class ProductTypeList : Partial {

        public void Init() {
            this.ProductTypes = Db.SQL<ProductType>("SELECT p FROM ProductType p");
        }
    }
}