# Generics
Generics are typically used to implement collections. In order to 
implement them in the manner of a template as necessary for this lab,
you need to restrict them with the IComparable constraint.  This
eliminates much of the utility available to a template, as in order
to use the Generic, you also need to implement and instruct your
class on the necessary functions of the IComparable class.  It also
restricts you from using any things that don't implement that interface.
<br><br>
Neither of our C# instructors have really used generics in the manner
demonstrated here. Interfaces are a closer analog to what we would
use in scenarios needing a template, but that's equally restrictive
in different way.  However, our instructors would be better able to
assist students in learning if we were to substitute interfaces here.
<br><br>
Mostly this is just a case of asking a language to do something it
was specifically designed not to do.