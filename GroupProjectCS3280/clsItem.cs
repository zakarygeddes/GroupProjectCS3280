using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectCS3280
{   /// <summary>
    /// Class used to create item object from db
    /// </summary>
    class clsItem
    {   /// <summary>
        /// property to hold item code
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// property to hold item description
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// property to hold item cost
        /// </summary>
        public string cost { get; set; }
        /// <summary>
        /// constructor for item, taking in from DB most likely
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="itemDesc"></param>
        /// <param name="itemCost"></param>
        public clsItem(string itemCode, string itemDesc, string itemCost)
        {
            try
            {
                this.code = itemCode;
                this.description = itemDesc;
                this.cost = itemCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
