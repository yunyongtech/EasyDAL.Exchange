﻿using System;
using System.Linq.Expressions;
using Yunyong.DataExchange.Enums;
using Yunyong.DataExchange.UserFacade.Join;

namespace EasyDAL.Exchange
{
    public static class FromExtension
    {

        public static FromX From<M>(this Joiner join, Expression<Func<M>> func)
        {
            var dic = join.DC.EH.ExpressionHandle(func)[0];
            dic.Action = ActionEnum.From;
            dic.Crud = CrudTypeEnum.Join;
            join.DC.AddConditions(dic);
            return new FromX(join.DC);
        }

    }
}
