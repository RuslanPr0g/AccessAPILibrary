using ApiAccessor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccessor.Accessors
{
    interface IAccessor
    {
        Task<IResponseModel> Load(string data, params string[] datas);
    }
}