using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Pay
{
    public interface IPayService
    {

        void AddGoodsAccount(goods_accountDto goodaccount);


        List<meth_payDto> GetMethPayList(bool? methisya, bool? meth_is_jie);


        void Addmeth_pay(meth_payDto meth_Pay);


        void Updatemeth_pay(meth_payDto meth_Pay);


        meth_payDto Getmeth_payId(int id);




        void Deletemeth_pay(int id);
    

    }
}
