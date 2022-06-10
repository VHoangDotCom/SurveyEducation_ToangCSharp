import React, { useState,useEffect } from 'react';
import EmptyList from '../../DetailView/Common/EmptyList';
import BlogList from '../../DetailView/Home/BlogList';
import Header from '../../DetailView/Home/Header';
import Image from '../../DetailView/Home/Image';
import SearchBar from '../../DetailView/Home/SearchBar';
import Footer from '../../DetailView/Home/Footer';
// import { blogList } from '../../data';
import axios from "axios";

const Home = () => {
  // const blogList = async () =>{
  //   let data = axios.get(`http://localhost:3000/survey/`);
  //   console.log(data);
  // }
  // console.log('blog',blogList)
  const [blogs, setBlogs] = useState([]);
  const [searchKey, setSearchKey] = useState('');
  const dateCheck = Date.now();
  let listData = []
  useEffect(() => {
    async function data_adding() {
    var request = await axios.get(`http://localhost:3000/survey/`);
    var getData = request.data
    getData.map((data)=>{
      if(new Date(data.endDate) >= dateCheck){
          listData.push(data)
      }
    })
   
    setBlogs(listData)
  }
  data_adding();
}, [searchKey])
  // Search submit
  const handleSearchBar = (e) => {
    e.preventDefault();
    handleSearchResults();
  };

  // Search for blog by category
  const handleSearchResults = () => {
    const allBlogs = blogs;
    const filteredBlogs = allBlogs.filter((blog) =>
      blog.document_name.toLowerCase().includes(searchKey.toLowerCase().trim())
    );
   
    setBlogs(filteredBlogs);
  };

  // Clear search and show all blogs
  const handleClearSearch = async() => {
     setBlogs(blogs);
    setSearchKey('');
  };

  return (
    <div>
      {/* Page Header */}
      <Header />
      <Image/>
      {/* Search Bar */}
      <SearchBar
        value={searchKey}
        clearSearch={handleClearSearch}
        formSubmit={handleSearchBar}
        handleSearchKey={(e) => setSearchKey(e.target.value)}
      />

      {/* Blog List & Empty View */}
      {!blogs.length ? <EmptyList /> : <BlogList blogs={blogs} />}

      <Footer/>
    </div>
  );
};

export default Home;
