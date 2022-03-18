using SoftMarket.Globals.DataGridStyles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace ZPSoft.GameZone.SGZAdmin.Classes
{
    public sealed class InfoGridStyle
    {
        public static GridViewDataColumn[] GetCashierStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdCashier",
                    HeaderText = "ID",
                    FieldName = "IdCashier",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "CashierName",
                    HeaderText = "Користувач",
                    FieldName = "CashierName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, gridViewCheckBoxColumn };
            }

        }
        public static GridViewDataColumn[] GetBonusesStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdBonus",
                    HeaderText = "ID",
                    FieldName = "IdBonus",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "BonusName",
                    HeaderText = "Назва Бонусної Схеми",
                    FieldName = "BonusName",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
               
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2};
            }
        }
        public static GridViewDataColumn[] GetGlobalsStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "Description",
                    HeaderText = "Налаштування",
                    FieldName = "Description",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "GlobalsValue",
                    HeaderText = "Значення",
                    FieldName = "GlobalsValue",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
                
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2};
            }

        }
        public static GridViewDataColumn[] GetCashierGroupStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdCashierGroup",
                    HeaderText = "ID",
                    FieldName = "IdCashierGroup",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "CashierGroupName",
                    HeaderText = "Найменування групи користувачів",
                    FieldName = "CashierGroupName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, gridViewCheckBoxColumn };
            }

        }
        public static GridViewDataColumn[] GetCashDeskStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdCashDesk",
                    HeaderText = "ID",
                    FieldName = "IdCashDesk",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "CashDeskName",
                    HeaderText = "Найменування каси",
                    FieldName = "CashDeskName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewTextBoxColumn textBoxColumn3 = new GridViewTextBoxColumn
                {
                    Name = "CardDeposit",
                    HeaderText = "Вартість картки",
                    FieldName = "CardDeposit",
                    TextAlignment = ContentAlignment.MiddleCenter,
                    FormatString= "{0:#','##}",

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2,textBoxColumn3, gridViewCheckBoxColumn };
            }

        }
        public static GridViewDataColumn[] GetNodePointStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdNodePoint",
                    HeaderText = "ID",
                    FieldName = "IdNodePoint",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "NodePointName",
                    HeaderText = "Найменування",
                    FieldName = "NodePointName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, gridViewCheckBoxColumn };
            }

        }
        public static GridViewDataColumn[] GetGroupUserStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdGroupUser",
                    HeaderText = "ID",
                    FieldName = "IdGroupUser",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "GroupUserName",
                    HeaderText = "Найменування",
                    FieldName = "GroupUserName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, gridViewCheckBoxColumn };
            }

        }
        public static GridViewDataColumn[] GetDeviceStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdDevice",
                    HeaderText = "ID",
                    FieldName = "IdDevice",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "DeviceName",
                    HeaderText = "Найменування",
                    FieldName = "DeviceName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewTextBoxColumn textBoxColumn3 = new GridViewTextBoxColumn
                {
                    Name = "IpAddress",
                    HeaderText = "IP Адреса",
                    FieldName = "IpAddress",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "Enabled",
                    HeaderText = "Статус Активності",
                    FieldName = "Enabled",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, textBoxColumn3, gridViewCheckBoxColumn };
            }
        }
        public static GridViewDataColumn[] GetGroupDeviceStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdGroupDevice",
                    HeaderText = "ID",
                    FieldName = "IdGroupDevice",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "GroupDeviceName",
                    HeaderText = "Найменування",
                    FieldName = "GroupDeviceName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };

                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2 };
            }
        }
        public static GridViewDataColumn[] GetPeriodsStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdPeriod",
                    HeaderText = "ID",
                    FieldName = "IdPeriod",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "PeriodName",
                    HeaderText = "Найменування",
                    FieldName = "PeriodName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewDateTimeColumn textBoxColumn3 = new GridViewDateTimeColumn
                {
                    FormatString = "{0:HH:mm}",
                    Name = "TimeBegin",
                    HeaderText = "Початок",
                    FieldName = "TimeBegin",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
                GridViewDateTimeColumn textBoxColumn4 = new GridViewDateTimeColumn
                {
                    FormatString = "{0:HH:mm}",
                    Name = "TimeEnd",
                    HeaderText = "Закінчення",
                    FieldName = "TimeEnd",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, textBoxColumn3, textBoxColumn4 };
            }
        }
        public static GridViewDataColumn[] GetDiscountStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdDiscount",
                    HeaderText = "ID",
                    FieldName = "IdDiscount",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "DiscountName",
                    HeaderText = "Найменування",
                    FieldName = "DiscountName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewCheckBoxColumn gridViewCheckBoxColumn = new GridViewCheckBoxColumn
                {
                    Name = "OnlyCash",
                    HeaderText = "Тільки готівка",
                    FieldName = "OnlyCash",
                    TextAlignment = ContentAlignment.MiddleCenter,
                };
                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, gridViewCheckBoxColumn };
            }
        }
        public static GridViewDataColumn[] GetHolidayStyle
        {
            get
            {
                GridViewDateTimeColumn textBoxColumn = new GridViewDateTimeColumn
                {
                    FormatString = "{0:dd MMMM yyyy}",
                    Name = "HolidayDate",
                    HeaderText = "Дата",
                    FieldName = "HolidayDate",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };
                return new GridViewDataColumn[] { textBoxColumn };
            }
        }
        public static GridViewDataColumn[] GetTariffStyle
        {
            get
            {
                GridViewTextBoxColumn textBoxColumn1 = new GridViewTextBoxColumn
                {
                    Name = "IdTariff",
                    HeaderText = "ID",
                    FieldName = "IdTariff",
                    TextAlignment = ContentAlignment.MiddleCenter,

                };

                GridViewTextBoxColumn textBoxColumn2 = new GridViewTextBoxColumn
                {
                    Name = "TariffName",
                    HeaderText = "Найменування",
                    FieldName = "TariffName",
                    TextAlignment = ContentAlignment.MiddleLeft,

                };
                GridViewTextBoxColumn textBoxColumn3 = new GridViewTextBoxColumn
                {
                    DataType = typeof(double),
                    Name = "DefaultPrice",
                    HeaderText = "Ціна за замовчуванням",
                    FieldName = "DefaultPrice",
                    TextAlignment = ContentAlignment.MiddleCenter,
                    FormatString = "{0:#','##}",

                };

                return new GridViewDataColumn[] { textBoxColumn1, textBoxColumn2, textBoxColumn3 };
            }
        }
    }

}

