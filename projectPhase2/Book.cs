﻿using System;
using System.Collections;
using System.Collections.Generic;
namespace projectPhase2
{
    public class Book : IBookFacade, ICelebrity
    {
        private string name;
        private string category;
        private string author;
        private string publisher;
        Queue<IObserver> observerList = new Queue<IObserver>();
        private int flag;
        public Book(string _name, string _category, string _author, string _publisher)
        {
            this.name = _name;
            this.category = _category;
            this.author = _author;
            this.publisher = _publisher;
        }

        public string getCategory()
        {
            return category;
        }

        public string getName()
        {
            return name;
        }
        public string getAuthor()
        {
            return author;
        }

        public string getPublisher()
        {
            return publisher;
        }
        // 
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                // Flag value changed. So notify observer(s).
                NotifyRegisteredObserver();
            }
        }
        public string Name
        {
         get
            {
            return name;
            }
        }
        public void Register(IObserver anObserver)
        {
            observerList.Enqueue(anObserver);
        }
        // To unregister a subscriber.
        public void Unregister(IObserver anObserver)
        {
            observerList.Dequeue();
        }
        // Notify all registered observers.
        public void NotifyRegisteredObserver()
        {
            foreach (IObserver observer in observerList)
            {
                observer.Update(this);
            }
        }
    }
}

