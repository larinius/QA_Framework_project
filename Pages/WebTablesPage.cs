using OpenQA.Selenium;
using Task3.Forms;
using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Pages
{
    internal class WebTablesPage : BaseForm
    {
        private AddUserForm addUserForm;
        private TextField userMail;
        private Button deleteUserButton;

        //private By addUserForm = By.XPath("//div[@role=\"rowgroup\"][4]//span[@title=\"Delete\"]");

        public WebTablesPage() :
            base(new TextField("//div[@class=\"main-header\"][normalize-space() = 'Web Tables']", "Web Table Page"), "Web Table Page")
        {
            addUserForm = new AddUserForm(new Button("//form[@id='userForm']", "Add User Form"), "Add User Form");
            deleteUserButton = new Button("//div[@role=\"rowgroup\"][4]//span[@title=\"Delete\"]", "Delete User");
        }

        public void ClickAddButton()
        {
            addUserForm.ClickAddButton();
        }

        public void ClickSubmitButton()
        {
            addUserForm.ClickSubmitButton();
        }

        public void FillAddUserForm(UserData data)
        {
            addUserForm.FillForm(data);
        }

        public bool IsFormDisplayed()
        {
            return addUserForm.IsDisplayed();
        }

        public bool UserIsDisplayed(string email)
        {
            userMail = new TextField($"//div[@role=\"gridcell\"][normalize-space() = '{email}']", "Email");

            if (userMail.GetText().Contains(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteNewUser()
        {
            deleteUserButton.Click();
        }

        public int GetUsersCount()
        {
            var row = new TextField("//div[@role=\"rowgroup\"][contains(.,\"@\")]", "User Row");

            return row.Count();
        }

        public void WaitFormClosed()
        {
            addUserForm.WaitUntilClosed();
        }
    }
}