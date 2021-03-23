using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessAccessLayer
{
  public   class Customerorders
    {
        public DataSet getDetails()
        {
            CustomerDal dal = new CustomerDal();
            var table = dal.findCustomer();

            ordersDal dal1 = new ordersDal();
            var orderstable = dal1.findorders();
            DataSet set = new DataSet();
            set.Tables.Add(table);
            set.Tables.Add(orderstable);
            return set;
        }
    }
}
