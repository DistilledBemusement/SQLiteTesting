using System;
using Android.App;
using Android.OS;
using Android.Widget;
using System.IO;
using SQLite;

namespace SQLiteTesting {
        [Activity(Label = "RegisterActivity")]
        public class RegisterActivity : Activity {
                EditText txtUsername, txtPassword;
                Button btnCreate;

                protected override void OnCreate(Bundle savedInstanceState) {
                        base.OnCreate(savedInstanceState);
                        SetContentView(Resource.Layout.newuser);
                        btnCreate = FindViewById<Button>(Resource.Id.buttonReg);
                        txtUsername = FindViewById<EditText>(Resource.Id.editTextUsername);
                        txtPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
                }

                private void BtnCreate_Click(object sender, EventArgs e) {
                        try {
                                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                                var db = new SQLiteConnection(dpPath);
                                db.CreateTable<LoginTable>();
                                LoginTable tbl = new LoginTable();
                                tbl.username = txtUsername.Text;
                                tbl.password = txtPassword.Text;
                                db.Insert(tbl);
                                Toast.MakeText(this, "Record Added Successfully", ToastLength.Short).Show();
                        }
                        catch (Exception ex) {
                                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
                        }
                }
        }
}