using BaiThi_UWP_DinhVanHoangAn.Entity;
using BaiThi_UWP_DinhVanHoangAn.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThi_UWP_DinhVanHoangAn.Models
{
    class ContactModel
    {
        public bool Insert(Contact contact)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Contact (Name, PhoneNumber) VALUES (?,?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.PhoneNumber);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public Contact SelectFirstContact(Contact contact)
        {
            try
            {
                var getContact = new Contact();
                string query = @"SELECT * FROM Contact Where Name = ? ORDER BY ROWID ASC LIMIT 1 ";
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare(query))
                {
                    stt.Bind(1, contact.Name);
                    if (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                    {
                        getContact.Id = Convert.ToInt32(stt[0]);
                        getContact.Name = (string)stt[1];
                        getContact.PhoneNumber = (string)stt[2];
                    }
                    return getContact;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Contact> Select()
        {
            try
            {
                List<Contact> lstNote = new List<Contact>();
                string query = @"SELECT * FROM Contact";
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare(query))
                {
                    while (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                    {
                        var getContact = new Contact();
                        getContact.Id = Convert.ToInt32(stt[0]);
                        getContact.Name = (string)stt[1];
                        getContact.PhoneNumber = (string)stt[2];
                        lstNote.Add(getContact);
                    }
                    return lstNote;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
