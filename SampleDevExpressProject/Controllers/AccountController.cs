using System;
using System.Web.Mvc;
using SampleDevExpressProject.DataAccessLayer;
using SampleDevExpressProject.Models.Account;

namespace SampleDevExpressProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return View(_accountService.GetAccounts());
        }

        public ActionResult AccountDetail(long id)
        {
            ViewBag.ShowBackButton = true;
            return View(_accountService.GetById(id));
        }

        public ActionResult GridViewPartial()
        {
            return PartialView("_Partial/GridViewPartial", _accountService.GetAccounts());
        }

        [ValidateAntiForgeryToken]
        public ActionResult GridViewCustomActionPartial(string customAction)
        {
            if (customAction == "delete")
                SafeExecute(() => PerformDelete());
            return GridViewPartial();
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(Account account)
        {
            return UpdateModelWithDataValidation(account, _accountService.AddNewRecord);
        }

        [ValidateAntiForgeryToken]
        public ActionResult UpdateAccount(Account account)
        {
            return UpdateModelWithDataValidation(account, _accountService.UpdateRecord);
        }

        private ActionResult UpdateModelWithDataValidation(Account account, Action<Account> updateMethod)
        {
            if (ModelState.IsValid)
                SafeExecute(() => updateMethod(account));
            else
                ViewBag.GeneralError = "Please, correct all errors.";
            return GridViewPartial();
        }

        private void PerformDelete()
        {
            if (!string.IsNullOrEmpty(Request.Params["SelectedRows"]))
                _accountService.DeleteRecords(Request.Params["SelectedRows"]);
        }
    }
}