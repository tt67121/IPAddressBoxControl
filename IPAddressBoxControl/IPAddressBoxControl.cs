using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace IPAddressBoxControl
{
    public partial class IPAddressBoxControl: UserControl
    {

        public IPAddressBoxControl()
        {
            InitializeComponent();
        }
        
        private void IPAddressBoxControl_Load(object sender, EventArgs e)
        {
            IPTextBox.Text = "000.000.000.000";
            IPTextBox.Size = Size;
            Height = IPTextBox.Height;
            IPTextBox.Top = 0;
            IPTextBox.Left = 0;
        }

        private void IPAddressBoxControl_Resize(object sender, EventArgs e)
        {
            IPTextBox.Size = Size;
            Height = IPTextBox.Height;
            IPTextBox.Top = 0;
            IPTextBox.Left = 0;
        }

        private void IPAddressBoxControl_Move(object sender, EventArgs e)
        {
            IPTextBox.Size = Size;
            Height = IPTextBox.Height;
            IPTextBox.Top = 0;
            IPTextBox.Left = 0;
        }

        [Description("IP地址")]
        public string IPAddress { 
            get => IPTextBox.Text; 
            set
            {
                string[] _IPdata = value.Split('.');
                if (_IPdata.Length != 4)
                {
                    IPTextBox.Text = "000.000.000.000";
                    return;
                }
                for (int i = 0; i<4; i++)
                {
                    short _IpD;
                    

                    if (!short.TryParse(_IPdata[i], out _IpD)) { 
                        IPTextBox.Text = "000.000.000.000";
                        return;
                    }

                    if ((_IPdata[i].Length-3)!= 0)
                    {
                        _IPdata[i] =  _IPdata[i].PadLeft(3,'0');
                    }
                    if (_IPMaskMode)
                    {
                        if (!(_IpD <= 255 && _IpD >= 0))
                            _IPdata[i] = "000";
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (!(_IpD <= 223 && _IpD >= 0))
                                _IPdata[i] = "223";
                        }
                        else
                        {
                            if (!(_IpD <= 255 && _IpD >= 0))
                                _IPdata[i] = "255";
                        }
                    }
                }

                IPTextBox.SelectionStart = 15;

                IPTextBox.Text = _IPdata[0] + '.' + _IPdata[1] + '.' + _IPdata[2] + '.' + _IPdata[3];

            }
    }
        [Description("是否输入掩码")]
        public bool IPAddressMaskMode { get => _IPMaskMode; set => _IPMaskMode = value; }
     
        private bool _IPMaskMode = false;
        private void IPTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //禁止输入
            if (IPTextBox.SelectionStart == 0)
                IPTextBox.SelectionStart = 3;


            string[] _IPdata  = IPTextBox.Text.Split('.');
            short _IPdatanum = (short)_IPdata.Length;
            if (_IPdatanum != 4) //防止出现异常格式
                IPTextBox.Text = "000.000.000.000";
            short _Ipos = GetInIpD();
            if (char.IsDigit(e.KeyChar))
            {
                _IPdata[_Ipos - 1] = _IPdata[_Ipos - 1].Substring(1) + e.KeyChar;

                if (_IPdata[_Ipos - 1][0] != '0')
                    IPTextBox.SelectionStart = IPTextBox.SelectionStart + 4;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                if (IPTextBox.SelectionStart == 0 && IPTextBox.SelectionLength == IPTextBox.Text.Length)
                {
                    // 文本框全选了  
                    IPTextBox.Text = "000.000.000.000";
                    IPTextBox.SelectionStart = 3;
                    IPTextBox.SelectionLength = 0;
                    return;
                }


                _IPdata[_Ipos - 1] = '0' + _IPdata[_Ipos - 1].Substring(0, _IPdata[_Ipos - 1].Length - 1);

                if (_IPdata[_Ipos - 1] == "000")
                {
                    if (_Ipos != 1)
                        IPTextBox.SelectionStart = IPTextBox.SelectionStart - 4;

                }




            }
            else if (e.KeyChar == '.')
            {
                IPTextBox.SelectionStart = IPTextBox.SelectionStart + 4;
            }
 
                short _ipa = short.Parse(_IPdata[_Ipos - 1]);
            if (_IPMaskMode)
            {
                if (!(_ipa <= 255 && _ipa >= 0))
                    _IPdata[_Ipos - 1] = "000";
            }
            else
            {
                if(_Ipos == 1)
                {
                    if(!(_ipa <= 223 && _ipa >= 0))
                        _IPdata[_Ipos - 1] = "223";
                }else
                {
                    if (!(_ipa <= 255 && _ipa >= 0))
                        _IPdata[_Ipos - 1] = "255";
                }
            }




            short _iptextboxcaretpos = (short)IPTextBox.SelectionStart;
            IPTextBox.Text = _IPdata[0] + '.'+ _IPdata[1] + '.'+ _IPdata[2] + '.'+ _IPdata[3];
            IPTextBox.SelectionStart = _iptextboxcaretpos;
        }
        private short GetInIpD()
        {
            short _caret = (short)IPTextBox.SelectionStart;
            if (_caret >= 0 && _caret <= 4)
                return 1;
            
            if (_caret >= 5 && _caret <= 8)
                return 2;
            
            if (_caret >= 9 && _caret <= 12)             
                return 3;
            
            if (_caret >= 13 && _caret <= 15)    
                return 4;
            return -1;
        }



        /// <summary>
        /// 插入符定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPTextBox_MouseClick(object sender, MouseEventArgs e)
        {
          short _caret =  (short)IPTextBox.SelectionStart;
            if (_caret >= 0 && _caret <= 4)
            { 
                IPTextBox.SelectionStart = 3;
                return;
            }
            if (_caret >= 5 && _caret <=8) 
            { 
                IPTextBox.SelectionStart = 7;
            return;
            }
            if (_caret >= 9 && _caret <= 12)
            {
                IPTextBox.SelectionStart = 11;
                return;
            }
            if (_caret >= 13 && _caret <= 15)
            {
                IPTextBox.SelectionStart = 15;
                return;
            }

        }

        private void IPTextBox_Resize(object sender, EventArgs e)
        {
            Size= IPTextBox.Size;
            Height = IPTextBox.Height;
            IPTextBox.Top = 0;
            IPTextBox.Left = 0;
        }
    }
}
