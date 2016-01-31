using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManager.DAL
{
    public class ProductManagerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductManagerContext>
    {
        
    }
}