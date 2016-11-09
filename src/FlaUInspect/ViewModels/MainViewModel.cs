using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.UIA2;
using FlaUI.UIA3;
using FlaUInspect.Core;

namespace FlaUInspect.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private HoverMode _hoverMode;
        private FocusTrackingMode _focusTrackingMode;
        private ITreeWalker _treeWalker;
        private AutomationBase _automation;
        private AutomationElement _rootElement;

        public MainViewModel()
        {
            Elements = new ObservableCollection<ElementViewModel>();
            StartNewInstanceCommand = new RelayCommand(o =>
            {
                var info = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location);
                Process.Start(info);
            });
        }

        public bool IsInitialized { get { return GetProperty<bool>(); } private set { SetProperty(value); } }

        public bool EnableHoverMode
        {
            get { return GetProperty<bool>(); }
            set
            {
                if (SetProperty(value))
                {
                    if (value) { _hoverMode.Start(); }
                    else { _hoverMode.Stop(); }
                }
            }
        }

        public bool EnableFocusTrackingMode
        {
            get { return GetProperty<bool>(); }
            set
            {
                if (SetProperty(value))
                {
                    if (value) { _focusTrackingMode.Start(); }
                    else { _focusTrackingMode.Stop(); }
                }
            }
        }

        public AutomationType SelectedAutomationType { get { return GetProperty<AutomationType>(); } private set { SetProperty(value); } }

        public ObservableCollection<ElementViewModel> Elements { get; private set; }

        public ICommand StartNewInstanceCommand { get; private set; }

        public ObservableCollection<DetailGroupViewModel> SelectedItemDetails => SelectedItemInTree?.ItemDetails;

        public ElementViewModel SelectedItemInTree { get { return GetProperty<ElementViewModel>(); } private set { SetProperty(value); } }

        public void Initialize(AutomationType selectedAutomationType)
        {
            SelectedAutomationType = selectedAutomationType;
            IsInitialized = true;

            if (selectedAutomationType == AutomationType.UIA2)
            {
                _automation = new UIA2Automation();
            }
            else
            {
                _automation = new UIA3Automation();
            }
            _rootElement = _automation.GetDesktop();
            var desktopViewModel = new ElementViewModel(_rootElement);
            desktopViewModel.SelectionChanged += DesktopViewModel_SelectionChanged;
            desktopViewModel.LoadChildren(false);
            Elements.Add(desktopViewModel);

            // Initialize TreeWalker
            _treeWalker = _automation.TreeWalkerFactory.GetControlViewWalker();

            // Initialize hover
            _hoverMode = new HoverMode(_automation);
            _hoverMode.ElementHovered += ElementToSelectChanged;

            // Initialize focus tracking
            _focusTrackingMode = new FocusTrackingMode(_automation);
            _focusTrackingMode.ElementFocused += ElementToSelectChanged;
        }

        private void ElementToSelectChanged(AutomationElement obj)
        {
            // Build a stack from the root to the hovered item
            var pathToRoot = new Stack<AutomationElement>();
            while (obj != null)
            {
                // Break on circular relationship (should not happen?)
                if (pathToRoot.Contains(obj) || obj.Equals(_rootElement)) { break; }

                pathToRoot.Push(obj);
                try
                {
                    obj = _treeWalker.GetParent(obj);
                }
                catch (Exception ex)
                {
                    // TODO: Log
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }

            // Expand the root element if needed
            if (!Elements[0].IsExpanded)
            {
                Elements[0].IsExpanded = true;
                System.Threading.Thread.Sleep(1000);
            }

            var elementVm = Elements[0];
            while (pathToRoot.Count > 0)
            {
                var elementOnPath = pathToRoot.Pop();
                var nextElementVm = FindElement(elementVm, elementOnPath);
                if (nextElementVm == null)
                {
                    // Could not find next element, try reloading the parent
                    elementVm.LoadChildren(true);
                    // Now search again
                    nextElementVm = FindElement(elementVm, elementOnPath);
                    if (nextElementVm == null)
                    {
                        // The next element is still not found, exit the loop
                        Console.WriteLine("Could not find the next element!");
                        break;
                    }
                }
                elementVm = nextElementVm;
                if (!elementVm.IsExpanded)
                {
                    elementVm.IsExpanded = true;
                }
            }
            // Select the last element
            elementVm.IsSelected = true;
        }

        private ElementViewModel FindElement(ElementViewModel parent, AutomationElement element)
        {
            foreach (var child in parent.Children)
            {
                if (child.AutomationElement.Equals(element))
                {
                    return child;
                }
            }
            return null;
        }

        private void DesktopViewModel_SelectionChanged(ElementViewModel obj)
        {
            SelectedItemInTree = obj;
            OnPropertyChanged(() => SelectedItemDetails);
        }
    }
}
