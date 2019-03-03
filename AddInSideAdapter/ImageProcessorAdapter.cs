using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.AddIn.Pipeline;
using Contract;

namespace AddInSideAdapter
{
    [AddInAdapter]
    public class ImageProcessorAdapter : ContractBase, Contract.IImageProcessorContract
    {
        private AddInView.ImageProcessorAddInView _view;
        public ImageProcessorAdapter(AddInView.ImageProcessorAddInView view)
        {
            _view = view;
        }

        public void Initialize(IHostObjectContract hostObj)
        {
            _view.Initialize(new HostObjectContractToViewAddInAdapter(hostObj));
        }

        public byte[] ProcessImageBytes(byte[] pixels)
        {
            return _view.ProcessImageBytes(pixels);
        }
    }

    public class HostObjectContractToViewAddInAdapter : AddInView.HostObject
    {
        private Contract.IHostObjectContract contract;
        private ContractHandle handle;

        public HostObjectContractToViewAddInAdapter(Contract.IHostObjectContract contract)
        {
            this.contract = contract;
            this.handle = new ContractHandle(contract);
        }

        public override void ReportProgress(int progressPercent)
        {
            contract.ReportProgress(progressPercent);
        }
    }
}
