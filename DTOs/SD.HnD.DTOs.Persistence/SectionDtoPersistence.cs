﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.7.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.QuerySpec;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.DTOs.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of SD.HnD.DTOs.DtoClasses.SectionDto from / to the entity model.</summary>
	public static partial class SectionPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, SD.HnD.DTOs.DtoClasses.SectionDto>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, SD.HnD.DTOs.DtoClasses.SectionDto> _compiledProjector = CreateProjectionFunc().Compile();
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static SectionPersistence() { }
	
		/// <summary>Extension method which produces a projection to SD.HnD.DTOs.DtoClasses.SectionDto which instances are projected from the 
		/// results of the specified baseQuery, which returns SD.HnD.DALAdapter.EntityClasses.SectionEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve SD.HnD.DTOs.DtoClasses.SectionDto instances</returns>
		public static IQueryable<SD.HnD.DTOs.DtoClasses.SectionDto> ProjectToSectionDto(this IQueryable<SD.HnD.DALAdapter.EntityClasses.SectionEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to SD.HnD.DTOs.DtoClasses.SectionDto which instances are projected from the 
		/// results of the specified baseQuery using QuerySpec, which returns SD.HnD.DALAdapter.EntityClasses.SectionEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve SD.HnD.DTOs.DtoClasses.SectionDto instances</returns>
		public static DynamicQuery<SD.HnD.DTOs.DtoClasses.SectionDto> ProjectToSectionDto(this EntityQuery<SD.HnD.DALAdapter.EntityClasses.SectionEntity> baseQuery, SD.HnD.DALAdapter.FactoryClasses.QueryFactory qf)
		{
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ"))
				.Select(() => new SD.HnD.DTOs.DtoClasses.SectionDto()
				{
					OrderNo = SectionFields.OrderNo.Source("__BQ").ToValue<System.Int16>(),
					SectionDescription = SectionFields.SectionDescription.Source("__BQ").ToValue<System.String>(),
					SectionID = SectionFields.SectionID.Source("__BQ").ToValue<System.Int32>(),
					SectionName = SectionFields.SectionName.Source("__BQ").ToValue<System.String>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_Section 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				});
		}

		/// <summary>Extension method which produces a projection to SD.HnD.DTOs.DtoClasses.SectionDto which instances are projected from the
		/// SD.HnD.DALAdapter.EntityClasses.SectionEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>SD.HnD.DALAdapter.EntityClasses.SectionEntity instance created from the specified entity instance</returns>
		public static SD.HnD.DTOs.DtoClasses.SectionDto ProjectToSectionDto(this SD.HnD.DALAdapter.EntityClasses.SectionEntity entity)
		{
			return _compiledProjector(entity);
		}
		
		private static System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, SD.HnD.DTOs.DtoClasses.SectionDto>> CreateProjectionFunc()
		{
			return p__0 => new SD.HnD.DTOs.DtoClasses.SectionDto()
			{
				OrderNo = p__0.OrderNo,
				SectionDescription = p__0.SectionDescription,
				SectionID = p__0.SectionID,
				SectionName = p__0.SectionName,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_Section 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
		}
		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query which is executed on the database to fetch the original entity instance the specified <see cref="dto"/> object was projected from.</summary>
		/// <param name="dto">The dto object for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use expression</returns>
		public static System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, bool>> CreatePkPredicate(SD.HnD.DTOs.DtoClasses.SectionDto dto)
		{
			return p__0 => p__0.SectionID == dto.SectionID;
		}

		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query which is executed on the database to fetch the original entity instances the specified set of <see cref="dtos"/> objects was projected from.</summary>
		/// <param name="dtos">The dto objects for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use expression</returns>
		public static System.Linq.Expressions.Expression<Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, bool>> CreatePkPredicate(IEnumerable<SD.HnD.DTOs.DtoClasses.SectionDto> dtos)
		{
			return p__0 => dtos.Select(p__1=>p__1.SectionID).ToList().Contains(p__0.SectionID);
		}

		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query on an IEnumerable in-memory set of entity instances to retrieve the original entity instance the specified <see cref="dto"/> object was projected from.</summary>
		/// <param name="dto">The dto object for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use func</returns>
		public static Func<SD.HnD.DALAdapter.EntityClasses.SectionEntity, bool> CreateInMemoryPkPredicate(SD.HnD.DTOs.DtoClasses.SectionDto dto)
		{
			return p__0 => p__0.SectionID == dto.SectionID;
		}
		
		/// <summary>Updates the specified SD.HnD.DALAdapter.EntityClasses.SectionEntity entity with the values stored in the dto object specified</summary>
		/// <param name="toUpdate">the entity instance to update.</param>
		/// <param name="dto">The dto object containing the source values.</param>
		/// <remarks>The PK field of toUpdate is set only if it's not marked as readonly.</remarks>
		public static void UpdateFromSection(this SD.HnD.DALAdapter.EntityClasses.SectionEntity toUpdate, SD.HnD.DTOs.DtoClasses.SectionDto dto)
		{
			if((toUpdate == null) || (dto == null))
			{
				return;
			}
			toUpdate.OrderNo = dto.OrderNo;
			toUpdate.SectionDescription = dto.SectionDescription;
			toUpdate.SectionName = dto.SectionName;
		}
	}
}

 