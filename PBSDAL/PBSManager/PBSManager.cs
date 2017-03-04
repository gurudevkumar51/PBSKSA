using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBSDAL.Entity;
using PBSDAL.DataAccess;

namespace PBSDAL.PBSManager
{
    public class PBSManager
    {
        private EventRepository evntRepo = new EventRepository();
        private QuoteRepository quoteRepo = new QuoteRepository();
        private PortfolioRepository portRepo = new PortfolioRepository();
        private TestimonialRepository tstmnlRepo = new TestimonialRepository();
        private UserRepository usrRepo = new UserRepository();
        private CareerRepository crrRepo = new CareerRepository();
        private ContactRepository cntctRepo = new ContactRepository();
        private TeamRepository TmRepo = new TeamRepository();
        
        //Events operations
        public List<Event> AllEvents()
        {
            return evntRepo.GetEvnts();
        }

        public int AddEvent(Event evnt)
        {
            return evntRepo.AddEvent(evnt);
        }

        public int ChangeEventStatus(int id,Boolean IsActive)
        {
            return evntRepo.ChangeStatus(id, IsActive);
        }

        public int UpdateEvent(Event evnt)
        {
            return evntRepo.UpdateEvent(evnt);
        }

        //Quotes operations
        public List<Quotes> AllQuotes()
        {
            return quoteRepo.GetQuotes();
        }

        public int AddQuote(Quotes quot)
        {
            return quoteRepo.AddQuote(quot);
        }

        public int ChangeQuoteStatus(int id, Boolean IsActive)
        {
            return quoteRepo.ChangeQuoteStatus(id, IsActive);
        }

        public int UpdateQuote(Quotes quot)
        {
            return quoteRepo.UpdateQuote(quot);
        }

        //Portfolio operations
        public List<Portfolio> AllPortfolio()
        {
            return portRepo.GetPortfolio();
        }

        public int AddPortfolio(Portfolio port)
        {
            return portRepo.AddPortfolio(port);
        }

        public int ChangePortfolioStatus(int id, Boolean IsActive)
        {
            return portRepo.ChangeStatus(id, IsActive);
        }

        public int UpdatePortfolio(Portfolio port)
        {
            return portRepo.UpdatePortfolio(port);
        }

        //Testimonial Operations
        public List<Testimonial> AllTestimonial()
        {
            return tstmnlRepo.GetTestimonial();
        }

        public int AddTestimonial(Testimonial tstmnl)
        {
            return tstmnlRepo.AddTestimonial(tstmnl);
        }

        public int ChangeTestimonialStatus(int id, Boolean IsActive)
        {
            return tstmnlRepo.ChangeStatus(id, IsActive);
        }

        public int UpdateTestimonial(Testimonial tstmnl)
        {
            return tstmnlRepo.UpdateTestimonial(tstmnl);
        }

        //User Operations
        public List<User> AllUsers()
        {
            return usrRepo.GetUsers();
        }
        
        //Career Operations
        public int AddResume(Career carr)
        {
            return crrRepo.AddCareer(carr);
        }

        //Contact Operations
        public int AddContact(ContactForm cntct)
        {
            return cntctRepo.AddContact(cntct);
        }

        //Team Operations
        public int AddTeam(Team Tm)
        {
            return TmRepo.AddTeam(Tm);
        }

        public List<Team> AllTeamMembers()
        {
            return TmRepo.GetTeams();
        }

        public int ChangeTeamStatus(int id, Boolean IsActive)
        {
            return TmRepo.ChangeStatus(id, IsActive);
        }
        public int UpdateTeam(Team Tm)
        {
            return TmRepo.UpdateTeam(Tm);
        }
    }
}
