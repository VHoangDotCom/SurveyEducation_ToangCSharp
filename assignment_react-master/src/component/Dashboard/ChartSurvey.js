import React, { useState, useEffect } from "react";
import axios from "axios";
import { Chart } from 'react-google-charts';



function ChartSurvey(props) {
  const {listData} = props;
      const data = listData.map((ele,i)=> {return ele})
    
          const options = {
          chart: {
            title: "Company Performance",
            subtitle: "Year, Survey, and Profit",
          },
        };
         
  return (
     <Chart
     chartType="Bar"
     width="700px"
     height="600px"
     data={data}
     options={options}
   />
  )
}

export default ChartSurvey