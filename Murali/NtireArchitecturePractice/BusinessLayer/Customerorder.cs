using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccessLayer;

namespace BusinessLayer
{
  public   class Customerorder
    {
        public DataSet getDetails()
        {
            CustomerDal dal = new CustomerDal();
            var table = dal.findCustomer();

            orders dal1 = new orders();
            var orderstable = dal1.findorders();
            DataSet set = new DataSet();
            set.Tables.Add(table);
            set.Tables.Add(orderstable);
            return set;
        }
    }
}
