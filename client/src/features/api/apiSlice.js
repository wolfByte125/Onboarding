import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BASE_URL, API_TAGS } from "../../constants/apiTags";

export const apiSlice = createApi({
  reducerpath: "apiSlice",

  baseQuery: fetchBaseQuery({
    baseUrl: BASE_URL,
    prepareHeaders: (headers, { getState }) => {
      const token = getState().auth?.user?.token;

      if (token) {
        headers.set("authorization", `Bearer ${token}`);
      }

      return headers;
    },
  }),

  tagTypes: Object.values(API_TAGS),
  refetchOnFocus: true,
  refetchOnMountOrArgChange: true,

  endpoints: (builder) => ({
    // BLOGS
    //---------------------------------
    getBlogs: builder.query({
      query: () => "BlogPost",
      providesTags: [API_TAGS.BLOGS],
    }),
    getBlogById: builder.query({
      query: (id) => `BlogPost/${id}`,
      provideTags: [API_TAGS.BLOGS],
    }),
    createBlog: builder.mutation({
      query: (data) => ({
        url: "BlogPost",
        method: "POST",
        body: data,
      }),
      invalidatesTags: [API_TAGS.BLOGS],
    }),
    updateBlog: builder.mutation({
      query: (data) => ({
        url: "BlogPost",
        method: "PUT",
        body: data,
      }),
      invalidatesTags: [API_TAGS.BLOGS],
    }),
    deleteBlog: builder.mutation({
      query: (id) => ({
        url: "BlogPost",
        method: "DELETE",
        params: id,
      }),
      invalidatesTags: [API_TAGS.BLOGS],
    }),
  }),
});

export const {
  // BLOGS
  //---------------------------------
  useGetBlogsQuery,
  useGetBlogByIdQuery,
  useCreateBlogMutation,
  useUpdateBlogMutation,
  useDeleteBlogMutation,
} = apiSlice;
