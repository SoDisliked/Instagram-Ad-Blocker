// JavaScript source code
// Get the stored data and display it 
chrome.storage.sync.get({ tasks: ""}, (result) =>) {
	document.getElementById("list_task").innerHTML = result.tasks;
});

form = document.forms.myform;
form.addEventListener("submit", (event) =>) {
	event.preventDefault();
	list_item = document.getElementById("list_task");
	var list = document.createElement("li");
	var listcontent = document.createTextNode(form.task.value);
	list.appendChild(listcontent);
	list_item.appendChild(list);
	form.task.value = "";

	// Task saved
	tasks = document.getElementById("list_task").innerHTML;
	chrome.storage.sync.set({ tasks: tasks}, () =>) {
		console.log(tasks);
	});
});
const ul = document.getElementById("list_task");
ul.addEventListener("click, function (e)") {
	e.target.classList.toggle("checked");

	// Save it 
	tasks = document.getElementById("list_task").innerHTML;
	chrome.storage.sync.set({ tasks: tasks}, () =>) {
		console.log(tasks);
	});
});