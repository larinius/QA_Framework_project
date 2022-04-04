using Task3.Framework;
using Task3.Framework.WebElements;

namespace Task3.Forms
{
    internal class AddUserForm : BaseForm
    {
        private TextField header;
        private Button addButton;
        private Button submitButton;

        private Input firstName;
        private Input lastName;
        private Input email;
        private Input age;
        private Input salary;
        private Input department;

        public AddUserForm(BaseElement uniqueEement, string name) : base(uniqueEement, name)
        {
            header = new TextField("//div[@id=\"registration-form-modal\"]", "Form Header");

            firstName = new Input("//input[@id=\"firstName\"]", "First Name");
            lastName = new Input("//input[@id=\"lastName\"]", "Last Name");
            email = new Input("//input[@id=\"userEmail\"]", "Email");
            age = new Input("//input[@id=\"age\"]", "Age");
            salary = new Input("//input[@id=\"salary\"]", "Salary");
            department = new Input("//input[@id=\"department\"]", "Department");

            addButton = new Button("//button[@id=\"addNewRecordButton\"]", "Add Button");
            submitButton = new Button("//button[@id=\"submit\"]", "Submit Button");
        }

        public void ClickAddButton()
        {
            addButton.Click();
        }

        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        public void FillForm(UserData data)
        {
            firstName.Sendkeys(data.FirstName);
            lastName.Sendkeys(data.LastName);
            email.Sendkeys(data.Email);
            age.Sendkeys(data.Age.ToString());
            salary.Sendkeys(data.Salary.ToString());
            department.Sendkeys(data.Department);
        }
    }
}