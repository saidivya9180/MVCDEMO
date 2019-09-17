using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDEMO.Models;

namespace MVCDEMO.Controllers
{
    public class TestController : Controller
    {
        public TESTDEMOContext DbContext { get; set; }
        // GET: Test
        public TestController()
        {
            DbContext = new TESTDEMOContext();
        }
        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditInv(EntityInventory inventory) //Insert or Update Inventory
        {
            var tblP = (from c in DbContext.EntityInventories
                        where c.EntityId == inventory.EntityId
                        select c).SingleOrDefault();
            if (tblP == null)
            {
                DbContext.EntityInventories.Add(inventory);
                DbContext.SaveChanges();
                ViewBag.InvDtls = inventory;
            }
            else
            {
                tblP.EntityName = inventory.EntityName;
                tblP.EmissionYear = inventory.EmissionYear;
                DbContext.SaveChanges();
                ViewBag.InvDtls = tblP;
            }

            return View();
        }
        [HttpGet]
        public ActionResult EditInv() //Populate Inventory details
        {
            EntityInventory inv = DbContext.EntityInventories.OrderByDescending(t => t.EntityId).FirstOrDefault();
            if (inv == null)
            {
                inv = new EntityInventory();
            }
            ViewBag.InvDtls = inv;
            return View();
        }
        public ActionResult TestingEditInv()
        {
            return View();

        }
        public ActionResult Editfacility() // Populate Entity Name
        {
            EntityInventory inv = DbContext.EntityInventories.OrderByDescending(t => t.EntityId).FirstOrDefault();
            if (inv == null)
            {
                inv = new EntityInventory();
            }
            ViewBag.EntityName = string.IsNullOrEmpty(inv?.EntityName) ? "" : inv.EntityName;
            ViewBag.Facilities = inv.Facilities;
            return View();

        }
        [HttpPost]
        public ActionResult AddFacility(Facility facility) //Insert or Update facility
        {
            var tblP = (from c in DbContext.Facilities
                        where c.FacilityID == facility.FacilityID
                        select c).SingleOrDefault();
            if (tblP == null)
            {
                var inv = DbContext.EntityInventories.OrderByDescending(t => t.EntityId).FirstOrDefault();
                facility.EntityID = inv.EntityId;
                DbContext.Facilities.Add(facility);
                DbContext.SaveChanges();
                ViewBag.facilities = facility;
            }
            else
            {
                tblP.FacilityName = facility.FacilityName;
                tblP.EmissionYear = facility.EmissionYear;
                DbContext.SaveChanges();
                ViewBag.facilities = facility;
            }
            return View();

        }
        [HttpGet]
        public ActionResult AddFacility(int id) //Update facility
        {
            var tblP = (from c in DbContext.Facilities
                        where c.FacilityID == id
                        select c).SingleOrDefault();
            ViewBag.facilities = tblP;
            return View();
        }
        public ActionResult AddFacilities() //New facility
        {
            Facility facility = new Facility();
            ViewBag.facilities = facility;
            return View("AddFacility");
        }
    }
}
