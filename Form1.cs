using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;
using TweetSharp.Model;
using TweetSharp.Serialization;
namespace TwetterDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TwitterService twitterService = new TwitterService("eFlPiYpQXPdn23BQ3Iy2C6XLx", "uEdnUNGkFyqSMHRyhnaz89zYa7UsqJdhdrx5rkPvNKAnlLfACS", "494252514-y9BEgi7W4NfA9xszjmWWW3BWDDTiG898Tn1JZMmI", "76lp0c5Jida6btaXFcc5JNRTMIbhQlaCwOXfLVgSUcyy0");
        private object twitterUser;
   
        private void button1_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            var veriler = twitterService.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions() { Count = 100 });
            foreach(var item in veriler)
            {
                listBox1.Items.Add(item.User.Name + "" + item.Text);
                listBox2.Items.Add(item.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            var veriler = twitterService.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { Count = 100 });
            foreach (var item in veriler)
            {
                listBox1.Items.Add(item.Text);
                listBox2.Items.Add(item.Id);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                twitterService.SendTweet(new SendTweetOptions() { Status = textBox1.Text });
                label1.Text = "İşlem Başarılı";
            }
            catch(Exception)
            {
                label1.Text = "İşlem Başarısız";
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            try
            {
                twitterService.DeleteTweet(new DeleteTweetOptions() { Id = long.Parse(listBox2.SelectedItem.ToString()) });
                label1.Text = "Tweet silindi";
            }
            catch(Exception)
            {
                label1.Text = "İşlem Başarısız";
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TwitterUser tuSelf = twitterService.GetUserProfile(new GetUserProfileOptions() { IncludeEntities = false, SkipStatus = false });
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            var veriler = twitterService.ListFollowerIdsOf(new ListFollowerIdsOfOptions() { ScreenName = "Tolga_Cbn" });

            foreach (var item in veriler)
            {

                listBox1.Items.Add(item);

            }
            ListFollowersOptions options = new ListFollowersOptions();
            options.UserId = tuSelf.Id;
            options.ScreenName = tuSelf.ScreenName;
            options.IncludeUserEntities = true;
            options.SkipStatus = false;
            options.Cursor = -1;
            List<TwitterUser> lstFollowers = new List<TwitterUser>();
            foreach (var item in lstFollowers)
            {

                listBox2.Items.Add(item);

            }



            //var followers = twitterService.ListFollowers(new ListFollowersOptions() {ScreenName = "Tolga_Cbn" });
            //while (followers.NextCursor != null)
            //{
            //    followers = twitterService.ListFollowers(user_id, followers.NextCursor);
            //    foreach (var follower in followers)
            //    {
            //        twitterUser.Followers.Add(follower.ScreenName);
            //    }
            //}


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var veriler = twitterService.ListFriends(new ListFriendsOptions() { ScreenName = "Tolga_Cbn" });
            foreach (var item in veriler)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
