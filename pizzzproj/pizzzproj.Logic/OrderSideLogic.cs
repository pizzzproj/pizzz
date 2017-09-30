using pizzzproj.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Logic
{
    public class OrderSideLogic
    {
        public int SideId { get; set; }
        public string SideName { get; set; }
        public string SideSize { get; set; }
        public static List<OrderSideLogic> Sides = new List<OrderSideLogic>();

        public static OrderSideLogic AddSide(Side side)
        {
            var addSide = new OrderSideLogic()
            {
                SideId = side.SideId,
                SideName = side.SideName,
                SideSize = side.SideSize
            };

            Sides.Add(addSide);

            return addSide;
        }

        //public
    }
}