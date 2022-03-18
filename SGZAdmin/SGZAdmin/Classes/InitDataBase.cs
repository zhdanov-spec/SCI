using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPSoft.GameZone.DatabaseComponents;
using ZPSoft.GameZone.SGZGlobals.DataSets;

namespace ZPSoft.GameZone.SGZAdmin.Classes
{
    public sealed class InitDataBase
    {
        public void InitCashierGroup()
        {
            GameZoneDataSet.CashierGroupRow newCashierGroup = Classes.GlobalVariable.AdminData.CashierGroup.NewCashierGroupRow();
            newCashierGroup.IdCashierGroup = 1;
            newCashierGroup.CashierGroupName = "Super Group User";
            newCashierGroup.Enabled = true;
            GlobalVariable.AdminData.CashierGroup.AddCashierGroupRow(newCashierGroup);
        }
        public void InitCashier(string password)
        {
            GameZoneDataSet.CashierRow newCashier = Classes.GlobalVariable.AdminData.Cashier.NewCashierRow();
            newCashier.IdCashier = 1;
            newCashier.IdCashierGroup = 1;
            newCashier.CashierName = "Super User";
            newCashier.Enabled = true;
            newCashier.SareaId = DataSetHolder.SareaId;
            newCashier.CashierCryptPassword = new SGZDomain.SubClasses.OtherLogic().GetHashString(password);
            newCashier.SuperUser = true;
            GlobalVariable.AdminData.Cashier.AddCashierRow(newCashier);
        }
        public void InitGroupUser()
        {
            GameZoneDataSet.GroupUserRow groupUserRow = Classes.GlobalVariable.AdminData.GroupUser.NewGroupUserRow();
            groupUserRow.IdGroupUser = 1;
            groupUserRow.GroupUserName = "Група за замовчуванням";
            groupUserRow.Enabled = true;
            GlobalVariable.AdminData.GroupUser.AddGroupUserRow(groupUserRow);
        }
        public void InitUsers()
        {
            GameZoneDataSet.UsersRow usersRow = Classes.GlobalVariable.AdminData.Users.NewUsersRow();
            usersRow.IdUser = 1;
            usersRow.IdGroupUser = 1;
            usersRow.UserName = "Новачок";
            usersRow.LastName = "Новачок";
            usersRow.Enabled = true;
            usersRow.SareaId = DataSetHolder.SareaId;
            usersRow.IdCashier = 1;
            usersRow.DateProfile = DateTime.Now;
            usersRow.DefaultUser = true;
            GlobalVariable.AdminData.Users.AddUsersRow(usersRow);

        }
        public void InitGlobals()
        {
            GameZoneDataSet.GlobalsRow globalsRow = Classes.GlobalVariable.AdminData.Globals.NewGlobalsRow();
            globalsRow.GlobalsKey = "ADDRESS";
            globalsRow.Description = "Адресса Закладу";
            GlobalVariable.AdminData.Globals.AddGlobalsRow(globalsRow);
            globalsRow = Classes.GlobalVariable.AdminData.Globals.NewGlobalsRow();
            globalsRow.GlobalsKey = "BOSS";
            globalsRow.Description = "Директор Закладу";
            GlobalVariable.AdminData.Globals.AddGlobalsRow(globalsRow);
            globalsRow = Classes.GlobalVariable.AdminData.Globals.NewGlobalsRow();
            globalsRow.GlobalsValue = "1";
            globalsRow.GlobalsKey = "DEFAULTUSER";
            globalsRow.Description = "Клієнт За Замовчуванням";
            GlobalVariable.AdminData.Globals.AddGlobalsRow(globalsRow);
            globalsRow = Classes.GlobalVariable.AdminData.Globals.NewGlobalsRow();
            globalsRow.GlobalsValue = "1";
            globalsRow.GlobalsKey = "GROUPUSERINFO";
            globalsRow.Description = "ID Групи Користувача Після Надачі Телефону";
            globalsRow = Classes.GlobalVariable.AdminData.Globals.NewGlobalsRow();
            globalsRow.GlobalsKey = "SAREANAMESHOT";
            globalsRow.Description = "Назва Закладу";
            GlobalVariable.AdminData.Globals.AddGlobalsRow(globalsRow);
            
        }
    }
}
