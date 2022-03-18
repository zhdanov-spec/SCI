using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SGZForms
{
    public class MainClass
    {
        public char GetKeyLetter(Int32 keyValue)
        {
            char letter = '~';
            switch(keyValue)
            {
                case 8:
                    letter = 'D';
                    break;
                case 13:
                    letter = 'E';
                    break;
                case 27:
                    letter = 'Q';
                    break;
                case 32:
                    letter = ' ';
                    break;
                case 70:
                    letter = 'А';
                    break;
                case 188:
                    letter = 'Б';
                    break;
                case 68:
                    letter = 'В';
                    break;
                case 85:
                    letter = 'Г';
                    break;
                case 76:
                    letter = 'Д';
                    break;
                case 84:
                    letter = 'Е';
                    break;
                case 222:
                    letter = 'Є';
                    break;
                case 186:
                    letter = 'Ж';
                    break;
                case 80:
                    letter = 'З';
                    break;
                case 66:
                    letter = 'И';
                    break;
                case 83:
                    letter = 'І';
                    break;
                case 221:
                    letter = 'Ї';
                    break;
                case 81:
                    letter = 'Й';
                    break;
                case 82:
                    letter = 'К';
                    break;
                case 75:
                    letter = 'Л';
                    break;
                case 86:
                    letter = 'М';
                    break;
                case 89:
                    letter = 'Н';
                    break;
                case 74:
                    letter = 'О';
                    break;
                case 71:
                    letter = 'П';
                    break;
                case 72:
                    letter = 'Р';
                    break;
                case 67:
                    letter = 'С';
                    break;
                case 78:
                    letter = 'Т';
                    break;
                case 65:
                    letter = 'Ф';
                    break;
                case 219:
                    letter = 'Х';
                    break;
                case 87:
                    letter = 'Ц';
                    break;
                case 88:
                    letter = 'Ч';
                    break;
                case 73:
                    letter = 'Ш';
                    break;
                case 79:
                    letter = 'Щ';
                    break;
                case 77:
                    letter = 'Ь';
                    break;
                case 190:
                    letter = 'Ю';
                    break;
                case 90:
                    letter = 'Я';
                    break;

            }
            return letter;
        }
        public char GetKey(Int32 keyValue)
        {

            char letter = ' ';
            switch (keyValue)
            {
                case 8:
                    letter = 'D';
                    break;
                case 13:
                    letter = 'E';
                    break;
                case 27:
                    letter = 'Q';
                    break;
                case 112:
                    letter = 'A';
                    break;
                case 48:
                    letter = '0';
                    break;
                case 96:
                    letter = '0';
                    break;
                case 45:
                    letter = '0';
                    break;
                case 49:
                    letter = '1';
                    break;
                case 97:
                    letter = '1';
                    break;
                case 35:
                    letter = '1';
                    break;
                case 50:
                    letter = '2';
                    break;
                case 98:
                    letter = '2';
                    break;
                case 40:
                    letter = '2';
                    break;
                case 51:
                    letter = '3';
                    break;
                case 99:
                    letter = '3';
                    break;
                case 34:
                    letter = '3';
                    break;
                case 52:
                    letter = '4';
                    break;
                case 100:
                    letter = '4';
                    break;
                case 37:
                    letter = '4';
                    break;
                case 53:
                    letter = '5';
                    break;
                case 101:
                    letter = '5';
                    break;
                case 12:
                    letter = '5';
                    break;
                case 54:
                    letter = '6';
                    break;
                case 102:
                    letter = '6';
                    break;
                case 39:
                    letter = '6';
                    break;
                case 55:
                    letter = '7';
                    break;
                case 103:
                    letter = '7';
                    break;
                case 36:
                    letter = '7';
                    break;
                case 56:
                    letter = '8';
                    break;
                case 104:
                    letter = '8';
                    break;
                case 38:
                    letter = '8';
                    break;
                case 57:
                    letter = '9';
                    break;
                case 105:
                    letter = '9';
                    break;
                case 33:
                    letter = '9';
                    break;
                case 46:
                    letter = ',';
                    break;
                case 188:
                    letter = ',';
                    break;
                case 190:
                    letter = ',';
                    break;
                case 191:
                    letter = ',';
                    break;
                case 110:
                    letter = ',';
                    break;
            }
            return letter;
        }
    }
}
