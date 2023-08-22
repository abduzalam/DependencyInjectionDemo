# DependencyInjection in .NET

In the following code Snippet, you can see that CustomerService class is heavily depends on CustomerDataAccess class to interact with database

The dependecy can be clearly visible in the code line no. 21 where we are creating a new instance of CustomerDataAccess class inorder to call GetCustomer Method

![image](https://github.com/abduzalam/DependencyInjectionDemo/assets/32676744/4b7434d1-5df7-4a98-aa0d-a19bd809069b)


