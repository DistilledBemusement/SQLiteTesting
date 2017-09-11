using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace SQLiteTesting {
        [Activity(Label = "SQLiteTesting", MainLauncher = true)]
        public class MainActivity : Activity {
                EditText txtUsername, txtPassword;
                Button btnSignIn, btnRegister;

                protected override void OnCreate(Bundle savedInstanceState) {
                        base.OnCreate(savedInstanceState);
                        // Set our view from the "main" layout resource
                        SetContentView(Resource.Layout.Main);
                        btnSignIn = FindViewById<Button>(Resource.Id.buttonLogin);
                        btnRegister = FindViewById<Button>(Resource.Id.buttonRegister);
                        txtUsername = FindViewById<EditText>(Resource.Id.editTextUsername);
                        txtPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
                        btnSignIn.Click += BtnSign_Click;
                        btnRegister.Click += BtnRegister_Click;
                        CreateDB();
                }

                private void BtnRegister_Click(object sender, EventArgs e) {
                        throw new NotImplementedException();
                }

                private void BtnCreate_Click(object sender, EventArgs e) {
                        StartActivity(typeof(RegisterActivity));
                }

                private void BtnSign_Click(object sender, EventArgs e) {
                        try {
                                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                                var db = new SQLiteConnection(dpPath);
                                var data = db.Table<LoginTable>(); //Call Table  
                                var data1 = data.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).FirstOrDefault(); //Linq Query  
                                if (data1 != null) {
                                        Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                                } else {
                                        Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                                }
                        } catch (Exception ex) {
                                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                        }
                }

                public string CreateDB() {
                        var output = "";
                        output += "Creating Database if it doesn't exist";
                        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                        var db = new SQLiteConnection(dbPath);
                        output += "\n Database Created...";
                        return output;
                }
        }
}

