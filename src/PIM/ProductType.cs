using Starcounter;

namespace PIM {

    /// <summary>
    /// The central PIM class: the one representing product types.
    /// </summary>
    [Database]
    public class ProductType {
        /// <summary>
        /// Unique, user given identity of the current type;
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A name to use to refer to the type by.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product type description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url to an image illustrating the current type.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// The parent type
        /// </summary>
        public ProductType ParentType;

        /// <summary>
        /// Product type children (only the direct ones).
        /// </summary>
        public QueryResultRows<ProductType> Children {
            get {
                return Db.SQL<ProductType>("SELECT p FROM ProductType p WHERE p.ParentType = ?", this);
            }
        }
    }
}