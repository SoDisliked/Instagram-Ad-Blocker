// JavaScript source code
chrome.contextMenus.create({
  id: "addtask",
  title: "Add this to your To DO list",
  contexts: ["selection"],
});

chrome.contextMenus.onClicked.addListener((iteminfo) => {
  //check if the clicked item is the required item
  if (iteminfo.menuItemId == "addtask") {
    var updated_tasks = "";
    //get the task list
    chrome.storage.sync.get({ tasks: [] }, (result) => {
      updated_tasks = result.tasks + "<li>" + iteminfo.selectionText + "</li>";
      // update the task list
      chrome.storage.sync.set({ tasks: updated_tasks }, () => {
        console.log("Data Updated");
      });
    });
  }
});