to add App_Code to the Web application - 
  - right click on the Project and Select "Add -> Add Asp.NET folders -> App_Code"
  - put the source code to the App_Code folder

after that you will need to
  - right click on the source code, click property
  - change the build action from "Content" -> "Compile"

then you can code against the source code, well, there is one gotchas, that the intellisense might not be working.