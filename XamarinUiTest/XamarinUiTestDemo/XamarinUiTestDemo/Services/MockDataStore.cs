using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinUiTestDemo.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinUiTestDemo.Services.MockDataStore))]
namespace XamarinUiTestDemo.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public async Task<bool> AddItemAsync(Item item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            await InitializeAsync();

            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Chase  Aucoin", Description = "Senior Enterprise Architect, Keyhole Software", Bio=@"As a passionate technologist it is my greatest joy to build solutions that bring organizations value not for 1-5 years, but that are built to flex and grow over the demands of the next 50+ years. I have been fortunate to work with some of the best minds in enterprise-scale data, services, dev-ops, BI, and people management. My knowledge is the culmination of aprox 20 of the best professionals in these fields spanning more than 100 years of expertise. I am in a unique position for a developer to be as business savvy as I am technically gifted.

                    My goal is to continue to work with the best, and to continue striving to be the best technologist I can.

                    while (!success) { Try(); }
                "},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ash Banaszek", Description="Sr. UX Specialist, Union Pacific Railroad", Bio = @"I am a Senior UX Project Consultant at Union Pacific in Omaha with over half a decade of experience in the UX field. I love melding psychology and technology; that's why I love the fields of Human-Computer Interaction and User Experience."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "James Bender", Description="Product Manager, Infragistics", Bio = @"James the Ignite UI Product Manager at Infragistics. He has worked as a developer and architect on everything from small, single-user applications to Enterprise-scale, multi-user systems. His specialties are .NET development and architecture, TDD, Web Development and JavaScript. James is a Microsoft MVP, ASP.NET Insider and author of the book ""Professional Test Driven Development with C#: Developing Real World Applications with TDD."" His new book ""Developing SPAs: Working with Visual Studio, Angualr and ASP.NET Web API"" will be out in 2017. James's Twitter ID is JamesBender"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Scott Bock", Description="Senior Software Consultant, Object Partners", Bio = @"Scott has developed Java, Groovy, Grails, and Javascript web apps for industries as varied as Defense, Health Care, Energy, Agriculture, Education and Commercial. Scott's favorite aspects of being a developer are solving problems, learning new technologies, and mentoring newer developers."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Lee Brandt", Description="Developer Evangelist, Okta", Bio = @"After almost two decades writing software professionally (and a few years unprofessionally before that), Lee Brandt still continues to learn every day. He has led teams in small and large companies and always manages to keep the business needs at the forefront of software development efforts. He speaks internationally about software development, from both a technical and business perspective, and loves to teach others what he learns. Lee writes software in Objective-C, JavaScript and C#… mostly. He is a Microsoft Most Valuable Professional in Visual C# and one of the directors of the Kansas City Developer Conference (KCDC). Lee is a decorated Gulf War veteran, a husband, a proud pet parent and loves to play the drums whenever he gets any spare time."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Kyle Brown", Description="Software Architect, MacPractice, Inc.", Bio = @"Kyle has been developing at MacPractice for 7 years, and is now a Software Architect.

He is also a new father, and has hobbies including Crochet, Quilting and Juggling."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Preston Chandler", Description="Managing Partner and Technology Lead, Smart Opex and VML", Bio = @"Preston has a passion for finding the best ways to get things done. This passion has led him to study Lean and Agile, which he uses on a daily basis to help his teams deliver awesomeness to the client. Though he started his undergraduate career studying music, Preston quickly realized that his greatest joy did not lie in music but in seeing and helping others learn, grow and accomplish greatness. Not only does he love solving all sorts of difficult problems with elegant solutions, he also wants to empower and uplift others to solve any conundrum that arises.

Over the last 12 years, he has assisted more than 50 different groups and organizations in transforming their operations with Lean and Agile principles. He has worked in such industries as pharmaceuticals labs, electronics assembly, food production, furniture manufacturing, product development and supply chain management. The companies and groups he has helped include: HON, Pepperidge Farm, Novartis, International Rectifiers, Johnson and Johnson, Merck, Pfizer, YRC, VML, Ford and Sprint. Preston currently is a Managing Partner and Expert at Smart Opex providing transformational coaching for Lean and Agile journeys."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "D'Arcy Cross", Description="Software Developer III, TCC", Bio = @"D'Arcy Cross is a senior developer with TCC in indianapolis, Indiana. He has spent his entire career as a functional programmer, and has used numerous technologies along the way.

He has worked in several industries from consulting to shipping logistics, and has recently begun speaking on topics from functional programming to angular 2 primers."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Arthur Doler", Description="Senior Software Engineer, Aviture", Bio = @"Arthur (or Art, take your pick) has been a software engineer for 13 years and has worked on things as exciting as analysis software for casinos and things as boring as banking websites. He is an advocate for talking openly about mental health and psychology in the technical world, and he spends a lot of time thinking about how we program and why we program, and about the tools, structures, cultures, and mental processes that help and hinder us from our ultimate goal of writing amazing things. His hair is brown and his thorax is a shiny blue color."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Gwendolyn Faraday", Description="Developer, Consultant, Ion Three", Bio = @"I'm a software developer from Indianapolis, IN. Professionally, I work mostly with cross-platform mobile technologies, React, and Node on AWS. For fun, I love dabbling in other languages, working on new IoT projects, and making apps that help people learn or build good habits through gamification."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Justin James", Description="Senior Software Engineer, Intel", Bio = @"I love to code, teach and share my knowledge with you.  I have been programming and designing web applications for over 20 years.  I am a frequent speaker at conferences, meetups and community events.  I regularly post to my blog on web and mobile development at http://digitaldrummerj.me.

In my free time, I help to put on hackathons for developers to code it forward to help Non-Profits with their IT needs as part of the Arizona Give Camp.   I also co-organize the Ionic Arizona and Phoenix Version Control meetups.

I live in Maricopa, Arizona and have worked at Intel for almost 20 years.  At Intel, I am part of amazing department called Freelance Nation where I get to freelance around the company picking work that intersects with my passions, skills and company needs while passing on the work that doesn't excite me.  

If you see me in the hallway, come up and say hi."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Duane Newman", Description="Co-Founder, Alien Arc Technologies, LLC", Bio = @"Duane is an entrepreneur and Co-Founder of Alien Arc Technologies, LLC where he focuses on creating modern apps targeting mobile devices, modern desktops, and the Internet of Things. As a technology enthusiast with a passion for good software he strives to bring solutions that improve or eliminate costly duplication and repetitive processes so more important things can be done. A fan of cross-platform native development, he promotes any development effort that gets a new app on his Windows Phone. Always interested in how software can improve processes he spends a lot of time working on DevOps issues with customers to automate workflow and reduce errors. You can find out more about his technical and other interests and read his random blogging on his site."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Spencer Schneidenbach", Description="Principal Consultant, Aviron Software", Bio = @"Spencer Schneidenbach is a web developer, Microsoft MVP, speaker, consultant, and blogger in the St. Louis area, focusing on JavaScript/TypeScript, C#, React/Redux, and ASP.NET. He is the owner of Aviron Software, a consultancy specializing in cloud- and web-based software solutions.

While not at work, he enjoys reading and spending time with his three kids and wife."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Brent Stewart", Description="Co-Founder, Alien Arc Technologies", Bio = @"As a professional software developer with almost two decades of experience, I have seen many development trends come and go and learned that there is not a shortcut to being a great developer. I enjoy teaching others what I have learned and try to mentor others whenever I can. I am a co-organizer of the Kansas City .NET User Group and love speaking at conferences.

I am a creator at heart and have started multiple businesses over the years in a variety of industries. My latest venture is Alien Arc Technologies which allows me to take my ideas and give them form. I love quality in all things and I always try to provide the best quality in everything I do. If it is worth doing, then it is worth doing right."},



            }.OrderBy(i => i.Text).ToList();

            foreach (Item item in _items)
            {
                items.Add(item);
            }

            isInitialized = true;
        }
    }
}
