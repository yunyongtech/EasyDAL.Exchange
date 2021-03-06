﻿using EasyDAL.Exchange.Common;
using EasyDAL.Exchange.Enums;
using EasyDAL.Exchange.UserFacade.Query;
using System;
using System.Linq.Expressions;

namespace EasyDAL.Exchange
{
    public static class CountExtension
    {


        /// <summary>
        /// select count(column)
        /// </summary>
        /// <param name="func">格式: it => it.Id</param>
        public static CountQ<M> Count<M,F>(this WhereQ<M> where, Expression<Func<M, F>> func)
        {
            var keyDic = where.DC.EH.ExpressionHandle(func)[0];
            var key = keyDic.ColumnOne;
            where.DC.AddConditions(new DicModel
            {
                ColumnOne = key,
                Param = key,
                ParamRaw = key,
                Action = ActionEnum.Select,
                Option = OptionEnum.Count,
                Crud = CrudTypeEnum.Query
            });
            return new CountQ<M>(where.DC);
        }


    }
}
