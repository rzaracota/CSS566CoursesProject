using System.Collections.Generic;
using serviceclient.types;

public class CoursesViewModel {
    public List<Course> Courses { get; set; }
    public string Message { get; set; } //Nav: What's the purpose of this?
    public List<Module> Modules { get; set; } // Nav: Seems redundant as Couse already has a list of modules
}