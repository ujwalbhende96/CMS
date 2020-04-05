using System;
using CMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetContactList());
        }

        public ActionResult InsertUpdateNewContact(int id = 0)
        {
            if (id == 0)
                return View(new CMSModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("CMS/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CMSModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult InsertUpdateNewContact(CMSModel _cmsModelObj)
        {
            if (_cmsModelObj.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("CMS", _cmsModelObj).Result;
                TempData["SuccessMessage"] = "Contact Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("CMS/" + _cmsModelObj.Id, _cmsModelObj).Result;
                TempData["SuccessMessage"] = "Contact Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("CMS/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Contact Deleted Successfully";
            return RedirectToAction("Index",GetContactList());
        }

        public IEnumerable<CMSModel> GetContactList()
        {
            IEnumerable<CMSModel> _cmsModel;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("CMS").Result;
            _cmsModel = response.Content.ReadAsAsync<IEnumerable<CMSModel>>().Result;
            return (_cmsModel);
        }
    }
}
