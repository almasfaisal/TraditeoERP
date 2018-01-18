using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditeo.Models.Utility
{
    public class Menus
    {
        private List<Models.Utility.Menus> _menuList;
        private StringBuilder _stringBuilder;
        [Key]
        public int MenuID { get; set; }
        [Required]
        public string MenuCode { get; set; }
        [Required]
        public string Menu { get; set; }
        public int? ParentID { get; set; }

        public byte RootID { get; set; }
        public bool IsActive { get; set; }
        public string TargetURL { get; set; }
        public byte IconTag { get; set; }
        public byte SortOrder { get; set; }

        public string BindTree(List<Models.Utility.Menus> menuList)
        {
            try
            {
                _menuList = menuList;
                //_dataSet = new Framework.BAL.Utility() { UserID = Convert.ToInt32(_hashTable["UserID"]), LanguageID = Convert.ToInt32(_hashTable["LanguageID"]), MenuTypeID = 1 }.ShowAssignMenu();
                List<Models.Utility.Menus> parentList = _menuList.Where(m => m.ParentID == null).ToList<Models.Utility.Menus>();
                
                _stringBuilder = new StringBuilder();
                _stringBuilder.Append("<ul id='mainmenu' class='ul_level1 treeview'>");
                for (int i = 0; i < parentList.Count; i++)
                {

                    _stringBuilder.Append("<li class='li_level1' ParentId='" + parentList[i].MenuID.ToString() + "' RootID='" + parentList[i].RootID.ToString() + "'>");
                    _stringBuilder.Append("<a onclick=" + parentList[i].TargetURL + ">" + parentList[i].Menu + "</a>");
                    _stringBuilder.Append("<div class='icon-Tag" + parentList[i].IconTag.ToString() + "' ></div>");

                    CreateNode(_menuList.Where(m => m.ParentID == parentList[i].MenuID).ToList<Models.Utility.Menus>(), 2);
                }
                _stringBuilder.Append("</ul>");
                return _stringBuilder.ToString();
            }
            catch
            {
                throw;
            }
        }

        public void CreateNode(List<Models.Utility.Menus> childList, int level)
        {
            try
            {
                if (childList.Count == 0)
                {
                    _stringBuilder.Append("</li>");
                    return;
                }
                for (int i = 0; i < childList.Count; i++)
                {
                    _stringBuilder.Append("<ul class='ul_level" + level + "'>");
                    _stringBuilder.Append("<li class='li_level" + level + "' ParentId='" + childList[i].MenuID.ToString() + "'  RootID='" + childList[i].RootID + "'>");
                    _stringBuilder.Append("<a href=" + childList[i].TargetURL + ">" + childList[i].Menu + "</a>");
                    _stringBuilder.Append("<div class='icon-Tag" + childList[i].IconTag.ToString() + "' ></div>");
                    if (childList[i].TargetURL != "ExpandMenu(this)" && childList[i].TargetURL.Contains("List") && !childList[i].TargetURL.Contains("600018") && !childList[i].TargetURL.Contains("600017") && !childList[i].TargetURL.Contains("800308") && !childList[i].TargetURL.Contains("600020") && !childList[i].TargetURL.Contains("600408"))
                    {
                        _stringBuilder.Append("<div class='iconplus' title='Add New' href=" + childList[i].TargetURL.Replace("List", "New") + ">+</div>");
                    }
                    CreateNode(_menuList.Where(m => m.ParentID == childList[i].MenuID).ToList<Models.Utility.Menus>(), 3);
                    _stringBuilder.Append("</ul>");
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
