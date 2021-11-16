namespace UnitTest.KeyboardWatcher
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SplayTree.KeyboardWatcher;

    [TestClass]
    public class KeyboardWatcher_Test
    {
        [TestMethod]
        public void TestIfKeyWatcherIsNull()
        {
            KeyboardWatcher watcher = new KeyboardWatcher();

            Assert.IsNotNull(watcher);
        }

        [TestMethod]
        public void TestIfEventFires()
        {
            KeyboardWatcher watcher = new KeyboardWatcher();
            string keyEvent = null;

            watcher.KeyPressed += delegate (object sender, KeyboardWatcherKeyPressedEventArgs e)
            {
                keyEvent = e.Key.ToString();
            };

            //watcher.Start();

            Assert.IsNull(keyEvent);
        }

        [TestMethod]
        public void TestEvent()
        {
            KeyboardWatcher watcher = new KeyboardWatcher();
            string keyEvent = null;

            watcher.KeyPressed += delegate (object sender, KeyboardWatcherKeyPressedEventArgs e)
            {
                keyEvent = e.Key.ToString();
            };
        }
    }
}
