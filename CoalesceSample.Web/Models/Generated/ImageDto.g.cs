using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CoalesceSample.Web.Models
{
    public partial class ImageDtoGen : GeneratedDto<CoalesceSample.Data.Models.Image>
    {
        public ImageDtoGen() { }

        private int? _ImageId;
        private byte[] _Content;

        public int? ImageId
        {
            get => _ImageId;
            set { _ImageId = value; Changed(nameof(ImageId)); }
        }
        public byte[] Content
        {
            get => _Content;
            set { _Content = value; Changed(nameof(Content)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(CoalesceSample.Data.Models.Image obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ImageId = obj.ImageId;
            this.Content = obj.Content;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(CoalesceSample.Data.Models.Image entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ImageId))) entity.ImageId = (ImageId ?? entity.ImageId);
            if (ShouldMapTo(nameof(Content))) entity.Content = Content;
        }
    }
}
