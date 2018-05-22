using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Software_Management_Course_Website.Models;

namespace Software_Management_Course_Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult Module() {

        //    var model = GetModuleModel(0);
        //    return View(model);
        //}
        public IActionResult Module(int id) {
            if (id < 0)
                id = 0;
            var model = GetModuleModel(id);
            return View(model);
        }
        private ModuleModel GetModuleModel(int id) {
            // Hardcoded for demo:
            var module = new ModuleModel[2];
            if (id < 0) id = 0;
            if (id >= module.Length) id = module.Length - 1;

            module[0] = new ModuleModel();
            module[0].Id = "1";
            module[0].Version = "a";
            module[0].Title = "The Practice of Cloud System Administration";
            module[0].HtmlContent = @"
<h3>Introduction</h3><br />This module contains information compiled based on this book about administering cloud systems. Though the needs of a cloud system versus a typical system have some similarities, a large distributed system has significant points that must be considered and addressed in order to maintain a stable environment.</p><h3>Info
<p>
This book attempts to expand on what was presumably introduced in the first volume of the series related to standard systems administration. Administering a cloud system shares much of what a non-distributed system requires with the addition of many considerations and abstractions.
The management aspects of systems administration are largely left up to the reader as it is not often addressed directly. Without the management concerns specifically laid out for the reader, many can be easily extracted from the real world examples given.
</p>
<h3>
DevOps
</h3>
<p>
DevOps, or Development Operations, is a major buzz word in the software industry these days but what does it really mean? It is easy to assume that DevOps is a special role that someone performance, however, this is far from the truth. Instead of a role or a specific job that people perform, DevOps is A culture focused on improving quality of the development and operation of software systems in particular how the two groups of people interact with each other and work together.
</p>
<h3>
Primary principles of DevOps
</h3>
<ol>
<li>Reduce organizational silos</li>
<li>Accept Failure as Normal</li>
<li>Implement Graduate Change</li>
<li>Leverage Tooling & Automation</li>
<li>Measure Everything</li>
</ol>
<h3>
Load Balancing
</h3>
<p>
The topic of load balancing came up often in the first section of this book. I found it interesting because the book uses the term for not only balancing load on services but also for balancing load and fallback of all portions of a cloud system, hardware and software. For example, a server with multiple processors on the same board would not only allow the server to handle more load but also survive a failed processor due to the redundancy.
The book also elaborates on the two key goals of creating multiple identical servers or services. If a service’s client load goes beyond what a single server can manage, an additional server would allow the load to be managed. Managing increased load is the primary intent of load balancing, however, when the capacity of a service requires all involved servers, the failure of a server results in the failure of the service.
Avoiding service outage is the second goal of load balancing. By deploying a server environment that exceeds the utilization by more than what a single machine can handle, the service becomes more resilient to an outage.
</p>
<h3>Consistency Availability Partition-Tolerance</h3>
<p>
When dealing with distributed systems a new problem arises that is not present in a centralized system when dealing with data for example. In a centralized system all clients connect to the same web server for example. The data is the same for all clients; if the server goes down, no one can access the service which also means all data is the same.
In contrast, for a distributed system, the previous does not hold true. Continuing with a web server as an example, instead of a single server we consider a single server that is mirrored across two datacenters. In a good state, all clients will see the same information regardless of the server they are connected to. In the typical scenario, an update to the server will not be committed until both servers are ready to commit, this is called consistency.
A distributed system such as this is vulnerable to several situations that are summarized by a principle call Capacity Availability and Partition Tolerance or CAP. CAP is very much similar to an idea in Relational Database Management Systems called ACID in that only two of the three features of CAP can be achieve at the same time. A simple example is losing connection between two datacenters. Consistency with mutable data would be impossible because the servers could no longer communicate with each other. A method to maintain consistency might be to shutdown the service which would render the services no longer available.</p>
<p>The decision of how many machines is one of cost of course due to the cost of servers but managers must not only consider the hardware and maintenance cost but also consider the cost of a service outage in the case of choosing the number of servers adequate for load balancing but not for redundancy. The book makes the analogy of extra servers being an insurance policy.</p>
<h3>Glossary</h3>
<ul>
<li><emp>Load-Balance:</emp> Distribution of clients to multiple servers offering the same service</li>
<li><emp>Consistency:</emp> The ability for a distributed system to maintain the same state between nodes.</li>
<li><emp>Availability:</emp> The state of a service able to functionally service requests.</li>
<li><emp>Partition-Tolerance:</emp> The ability for a distributed system to remain functionality in a situation where the distributed components can no longer communicate with each other.</li>
<li><emp>CAP: Consistency Availability Partition-Tolerance:</emp> A principle which states that a distributed system can not maintain all 3 of these non-functional requirements in all scenarios. Similar to RDBMS ACID compliancy.</li>
<li><emp>Toil:</emp> manual, automatic, and repetitive tasks that take away from other productive work.</li>
<li><emp>Multitenancy:</emp> The presence of multiple customer environments within the same physical server.</li>
</ul>
<h3>Quiz</h3>
<ol>
<li>How does the waterfall method of development affect the costs of creating a product</li>
<li>Should a software development manager force his teams to use a tool that has been proven to increase productivity of other teams</li>
<li>ow can a cloud hosted infrastructure such as Amazon Web Services reduce the cost of development.</li>
<li>Describe a situation where a company should choose to run their own datacenter rather than utilizing existing cloud options.</li>
</ol>
<h3>Videos</h3>
<ul>
<li>https://www.youtube.com/watch?v=aLtn_nV5rHA (Site reliability engineer at pinterest; what I do and what I make)</li>
<li>https://www.youtube.com/watch?v=uTEL8Ff1Zvk (What is the difference between SRE and DevOps?)</li>
</ul>
<h3>Related Works</h3>
<p>The following is a short list of books that contain similar content to this title and could serve as reference for more exploration of the topics presented.</p>
<ul>
<li>System administration (volume 1)
<li>The Twelve-Factor App (https://12factor.net/)</li>
</div>            
";
            module[1] = new ModuleModel();
            module[1].Id = "1";
            module[1].Version = "a";
            module[1].Title = "Peopleware";
            module[1].HtmlContent = @"
            
<div class=""row"">
            <div class=""col-sm-3"">
                <nav id=""toc"" data-spy=""affix"" data-toggle=""toc"" class=""affix"">
                    <a href=""https://www.amazon.com/Peopleware-Productive-Projects-Teams-3rd/dp/0321934113/"">
                            <img src=""https://images-na.ssl-images-amazon.com/images/I/61lAwzXfQiL._SX385_BO1,204,203,200_.jpg"" style=""width: 40%; height: 40%;"" alt=""Peopleware Front Cover"">
                        </a>
                <ul class=""nav""><li class=""""><a href=""#literature-review"">Literature review</a></li><li class=""""><a href=""#managers"">Managers</a></li><li class=""""><a href=""#employees"">Employees</a></li><li class=""active""><a href=""#team"">Team</a><ul class=""nav""><li class=""active""><a href=""#teamicide"">Teamicide</a></li></ul></li><li class=""""><a href=""#healthy-culture"">Healthy culture</a><ul class=""nav""><li class=""""><a href=""#change"">Change</a></li><li class=""""><a href=""#fun-to-work"">Fun to work</a></li></ul></li><li class=""""><a href=""#videos-1"">Videos</a></li><li class=""""><a href=""#related-modules"">Related Modules</a></li></ul></nav>

            </div>
            <div class=""col-sm-9"">
                <div class=""row"">
                    <!-- <div class=""col-xs-8""> -->
                    <h1 id=""literature-review"">Literature review</h1>
                    <h3><em>Peopleware: Productive Projects and Teams</em></h3>
                    <h4>Authors:  Tom DeMarco and Timothy Lister</h4>
                    <h5>Reviewer: Trang Quang</h5>
                    <p>
                        This is a popular book on software and team management. Its first edition was published in 1987, and latest edition (3rd) published in 2013. Still it presents a vast amount of insights on how people factor works in software development and phenomena greatly
                        relevant to current workplace. The book approaches sociological or 'political' problems such as group chemistry and team jelling, ""flow time"" and quiet in the work environment, and the high cost of turnover.
                    </p>
                    <blockquote>
                        The major problems of our work are not so much <i>technological</i> as <em>sociological</em> in nature.
                    </blockquote>
                    <!-- </div> -->
                </div>
                <div id=""main-content"">
                    <div class=""docs-section"">
                        <!-- <div class=""col-xs-8""> -->
                        <h1 id=""managers"">Managers</h1>
                        <p>
                            Manager pushes for more Productivity by pressuring employees working overtime. The problem is, Overtime is like sprinting. It may work in a short term but definitely not in a long term. Normal people will try to compensate for each hour of overtime. Examples are coming in late in the morning, going for regular tea breaks, or downright working less in low time. Throughout the effort, there will be more or less an hour of “undertime” for every hour of overtime. Overtime does not guarantee improved productivity in the long run. What’s more, overtime will affect employees’ personal lives eventually. Sensible people won’t tolerate Overtime for long, they will quit. How does it cost to managers?
                        </p>
                        <p>
                            Interestingly, when we are discussing about productivity, we rarely mention “turnover rate”. The cost of turnover could be calculated by considering the loss happens when employees quit. Imagine that one employee quit and manager can bring in a new member the next day. This new member, let’s say Ralph, obviously could not produce the same amount of work in first few days compared to the old employee, named Kelly. Day one, Ralph will need to fill out all those benefit forms, set up his machine, etc. Obviously his net production is zero, even negative in case he requests help from other teammates. Over the course of 6 months, let say he manages to ramp up linearly and finally is able to perform the same as Kelly. The company has lost about 3-month cost to replace an employee. This could cost the company more, the book gives 2-year estimate, if one has to replace an experienced worker in a niche field.
                        </p>
                        <p>An easy-to-remember takeaway for managers:</p>
                        <ul>
                            <li>Get the RIGHT people.</li>
                            <li>Make them HAPPY so they don't want to leave.</li>
                            <li>Turn them LOOSE.</li>
                        </ul>
                        <blockquote>
                            The manager’s function is not to make people work, but to make it <i>possible</i> for people to work.
                        </blockquote>
                        <!-- </div> -->
                    </div>
                    <div class=""docs-section"">
                        <!-- <div class=""col-xs-8""> -->
                        <h1 id=""employees"">Employees</h1>
                        <p>
                            One must realize that employees in software industry are thinking workers. Their production roots in their creative activities. In order to produce real work, they need to get into a FLOW. That says it take time for them to get into immersion, and any
                            interruption, say noise or meetings, could greatly affect their flow.
                        </p>
                        <p>
                            Young people has a problem with focus when they grow up with all the readily available technologies around them, i.e. mobile phone. This leads to a state called Constant Partial Attention, and this partiality won’t do any good because they could not focus
                            100% on a task, resulting in half-good production. This introduces a risk of preventing them blending into a team and affecting their productivity.
                        </p>
                        <!-- </div> -->
                    </div>
                    <div class=""docs-section"">
                        <!-- <div class=""col-xs-8""> -->
                        <h1 id=""team"">Team</h1>
                        <p>
                            A manager’s life can be so much easier when they could put together a productive team. The book defines a JELLED team as a team with closing knit members, who could make miracles happen in development, or the whole is greater than the sum of the parts. Once succeeded, they have the momentum to make it happen again and again. A few signs about this JELLED team are:
                        </p>
                        <ul>
                            <li>Low turnover, during projects and in the middle of tasks</li>
                            <li>Strong sense of identity</li>
                            <li>A sense of eliteness</li>
                            <li>Joint ownership of the product</li>
                            <li>Obvious enjoyment working in the team</li>
                        </ul>
                        <h2 id=""teamicide"">Teamicide</h2>
                        <p>
                            So how to make this team happen? It was so difficult to come up with the right formula that the authors take the <i>inversion</i> approach, coming up with a list of things that make team impossible, so called Teamicide.
                        </p>
                        <ul>
                            <li>Defensive management</li>
                            <li>Bureaucracy</li>
                            <li>Physical separation</li>
                            <li>Fragmentation of time</li>
                            <li>Clique control</li>
                            <li>Competition</li>
                        </ul>
                        <p>One last word, when people mentions “Management Team”, the “Team” part does not make sense. The book says team normally only happens at the bottom of the hierarchy. Team doesn’t happen at management layer since there exists all the conditions of Teamicide such as competition, physical separation, fragmentation of time, and lastly not sharing ownership of a product.
                        </p>
                        <!-- </div> -->
                    </div>
                    <div class=""docs-section"">
                        <!-- <div class=""col-xs-8""> -->
                        <h1 id=""healthy-culture"">Healthy culture</h1>
                        <p>
                            Teams and projects exist within a context provided by the larger organization, which is called the corporate culture. Even when managers do not have the power to change the corporate culture, they still need to be aware of things that will benefit or inhibit a healthy culture:
                        </p>
                        <ul>
                            <li>Avoid ultimate management sin - ""waste people's time""</li>
                            <li>Meetings vs ceremonies: A meeting is a ceremony when the more the merrier and at the end of that, there is no action point.</li>
                            <li>E(vil)mail</li>
                            <li>Making Change possible</li>
                            <li>Building a community that employees feel they belong to</li>
                        </ul>
                        <p>Among them, a manager would have to introduce CHANGE sooner or later, under the pressure of evolving technology and production-cost improvement.</p>
                        <h2 id=""change"">Change</h2>

                        <blockquote>MANTRA: The fundamental response to change is not logical, but emotional.
                        </blockquote>
                        <img src=""../../images/change_models.png"" alt=""Naive model vs Satir Change model"" style=""width: 75%; height: 75%;"">
                        <p>
                            The importance of Satir Change model is that it alerts us Chaos is an integral part of Change. If people think in Naive model and mistake Chaos as “New Status Quo”, they will tend to change back since the New Status Quo is so chaotic. When we are aware of Chaos, the chances of dealing sensibly with it will be much improved.Furthermore, in order to make change happen, managers should make a tolerance environment where a quota of errors and failure is acceptable. Without failure accepted, people won’t take a chance.
                        </p>
                        <h2 id=""fun-to-work"">Fun to work</h2>
                        <p>Lastly, the ultimate goal of managers will be to make employees enjoy their work. The book proposes a list of ways to introduce a little of “chaos” into the ordered world:</p>
                        <ul>
                            <li>Pilot projects</li>
                            <li>War games</li>
                            <li>Brainstorming</li>
                            <li>Training, celebrations, retreats</li>

                        </ul>
                        <!-- </div> -->
                    </div>

                    <div class=""docs-section"" id=""videos"">

                        <h1 id=""videos-1"">Videos</h1>
                        <h6>Timothy Lister talking at Google Talk</h6>
                        <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/DcRTObGWFuE"" frameborder=""0"" allow=""autoplay; encrypted-media"" allowfullscreen=""""></iframe>

                        <h6>Tom DeMarco talking about Leadership - new chapter in 3rd edition</h6>
                        <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/cmv9REAAHxU"" frameborder=""0"" allow=""autoplay; encrypted-media"" allowfullscreen=""""></iframe>
                    </div>
                </div>

                <div class=""docs-section"">
                    <!-- <div class=""col-xs-8""> -->
                    <h1 id=""related-modules"">Related Modules</h1>
                    <ul>
                        <li>
                            <a href=""#"">...</a>
                        </li>
                        <li>
                            <a href=""#"">...</a>
                        </li>
                        <li>
                            <a href=""#"">...</a>
                        </li>
                    </ul>
                    <!-- </div> -->
                </div>
            </div>
        </div>           

";
            return module[id];
        }
    }
}
