using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Real
{
    public class CompanyController
    {
        public CompanyRepository CompanyRepository;

        public CompanyController()
        {
            CompanyRepository = new CompanyRepository();
        }

        public List<Company> GetCompanyList()
        {
            return CompanyRepository.GetCompanies();
        }

        public void CreateCompany(string name, string field, string cvrNumber)
        {
            Company company = new Company(name, field, cvrNumber);
            CompanyRepository.AddCompany(company);
        }

        public void CreateCompany(string name, string field, string cvrNumber, string contact)
        {
            Company company = new Company(name, field, cvrNumber, contact);
            CompanyRepository.AddCompany(company);
        }

        public void CreateCompany(string name, string field, string cvrNumber, string phoneNumber, string eMail)
        {
            Company company = new Company(name, field, cvrNumber, phoneNumber, eMail);
            CompanyRepository.AddCompany(company);
        }

        public void UpdateSelectedCompany(int id, string companyName, string field, string phoneNumber, string eMail, 
            string cvrNumber, string status, bool followUpLetter, string comment)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.UpdateCompany(selectedCompany, companyName, field, phoneNumber, eMail, cvrNumber, status, followUpLetter, comment);
        }

        public void RegisterFirstContact(int id, DateTime date, string status, bool followUpLetter, string comment)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.RegisterFirstContact(selectedCompany, date, status, followUpLetter, comment);
        }

        public void DeleteSelectedCompany(int id)
        {
            Company selectedCompany = CompanyRepository.GetCompanyByID(id);
            CompanyRepository.DeleteCompany(selectedCompany);
        }
    }
}
