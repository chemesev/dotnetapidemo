function TasksViewModel() {
        var self = this;
        self.apiuri = 'http://localhost:5000/api/tasks/';
        self.tasks = ko.observableArray();

        self.ajax = function(uri, method, data) {
            var request = {
                url: uri,
                type: method,
                contentType: "application/json",
                accepts: "application/json",
                cache: false,
                dataType: 'json',
                data: JSON.stringify(data)
            };
            return $.ajax(request);
        }

        self.beginAdd = function() {
            $('#add').modal('show');
        }
        self.beginEdit = function(task) {
            editTaskViewModel.setTask(task);
            $('#edit').modal('show');
        }
        self.edit = function(task, data) {
            self.ajax(task.uri(), 'PUT', data).done(function(res) {
                self.updateTask(task, res.task);
            });
        }
        self.updateTask = function(task, newTask) {
            var i = self.tasks.indexOf(task);
            self.tasks()[i].uri(newTask.id);
            self.tasks()[i].title(newTask.title);
            self.tasks()[i].description(newTask.description);
            self.tasks()[i].done(newTask.done);
        }        
        self.remove = function(task) {
            alert("Remove: " + task.title());
        }
        self.markInProgress = function(task) {
            task.done(false);
        }
        self.markDone = function(task) {
            task.done(true);
        }

        self.ajax(self.apiuri, 'GET').done(function(data) {
            for (var i = 0; i < data.length; i++) {
                self.tasks.push({
                    uri: ko.observable(data[i].id),
                    title: ko.observable(data[i].title),
                    description: ko.observable(data[i].description),
                    done: ko.observable(data[i].done)
                });
            }
        });

        self.add = function(task)
        {
            self.ajax(self.apiuri, 'POST', task).done(function(data) {
                self.tasks.push({
                    uri: ko.observable(data.id),
                    title: ko.observable(data.title),
                    description: ko.observable(data.description),
                    done: ko.observable(data.done)
                });
            });
        }
}
function AddTaskViewModel() {
        var self = this;
        self.title = ko.observable();
        self.description = ko.observable();

        self.addTask = function() {
            $('#add').modal('hide');
            tasksViewModel.add({
                title: self.title(),
                description: self.description()
            });
            self.title("");
            self.description("");
        }
}
function EditTaskViewModel() {
        var self = this;
        self.title = ko.observable();
        self.description = ko.observable();
        self.done = ko.observable();

        self.setTask = function(task) {
            self.task = task;
            self.title(task.title());
            self.description(task.description());
            self.done(task.done());
            $('edit').modal('show');
        }
        self.editTask = function() {
            $('#edit').modal('hide');
            tasksViewModel.edit(self.task, {
                title: self.title(),
                description: self.description() ,
                done: self.done()
            });
        }
}
var tasksViewModel = new TasksViewModel();
var addTaskViewModel = new AddTaskViewModel();
var editTaskViewModel = new EditTaskViewModel();
ko.applyBindings(tasksViewModel, $('#main')[0]);
ko.applyBindings(addTaskViewModel, $('#add')[0]);
ko.applyBindings(editTaskViewModel, $('#edit')[0]);
