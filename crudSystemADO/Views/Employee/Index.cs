using crudSystemADO.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Threading;
using System;

@model List<crudSystemADO.Models.Employee>
@{
	ViewData["Title"] = "Employee Details";
var errorMessage = TempData["errorMessage"]?.ToString();
var successMessage = TempData["successMessage"]?.ToString();
}
< h3 > @ViewData["Title"]?.ToString() </ h3 >
< hr />
@if(!string.IsNullOrWhiteSpace(successMessage))
{

    < div class= "alert alert-success" >

        < b > Success : </ b > @successMessage
        < button type = "button" class= "btn-close float-end" data - bs - dismiss = "alert" aria - label = "Close" ></ button >

    </ div >
}
else if (!string.IsNullOrWhiteSpace(errorMessage))
{

    < div class= "alert alert-danger" >

        < b > Error : </ b > @errorMessage
        < button type = "button" class= "btn-close float-end" data - bs - dismiss = "alert" aria - label = "Close" ></ button >

    </ div >
}
< form >

    < button asp - action = "Create" asp - controller = "Employee" class= "btn btn-primary mb-3" > Create Employee </ button >

    < table class= "table table-bordered table-responsive table-hover" >

        < thead >

            < tr class= "table-active" >

                < th > Id </ th >

                < th > FirstName </ th >

                < th > LastName </ th >

                < th > Status </ th >

                < th > State </ th >

                < th > CheckBox1 </ th >

                < th > CheckBox2 </ th >

                < th > Action </ th >


            </ tr >

        </ thead >

        < tbody >
            @if(Model != null && Model.Any())

            {
    @foreach(var employee in Model)

                {

                    < tr >

                        < td > @employee.Id </ td >

                        < td > @employee.FirstName </ td >

                        < td > @employee.LastName </ td >

                        < td > @employee.Status </ td >

                        < td > @employee.State </ td >

                        < td > @employee.CheckBox1 </ td >

                        < td > @employee.CheckBox2 </ td >

                        < td >

                            < div class= "btn-group btn-group-sm" >

                                < a asp - controller = "Employee" asp - action = "Edit" asp - route - id = "@employee.Id" class= "btn btn-primary" > Edit </ a >

                                < a asp - controller = "Employee" asp - action = "Delete" asp - route - id = "@employee.Id" class= "btn btn-danger" > Delete </ a >

                            </ div >

                        </ td >

                    </ tr >
					
				}

			}

            else
{

                < tr >

                    < td colspan = "8" >

                        < div >
                            No Employees available at this moment!
                        </ div >


                    </ td >

                </ tr >

            }

        </ tbody >

    </ table >
</ form >