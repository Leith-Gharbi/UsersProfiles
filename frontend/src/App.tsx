import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import 'antd/dist/antd.css';
import styled from 'styled-components';
import { Button, Card, Image, Modal, Row } from 'antd';
import Avatar from 'antd/lib/avatar/avatar';
import axios from 'axios';
import { DownloadOutlined, InfoCircleTwoTone } from '@ant-design/icons';

const CARD_COLOR_ACTIVE = '#d2d2d2';

function App() {
  const [data, setData] = useState<any[]>([]);
  useEffect(() => {
    const response = axios
      .get(`https://localhost:44353/api/USers/from-url`)
      .then((res) => {
        const persons = res.data;
        setData(persons);
        console.log(res.data);
      });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <Wrapper>
          <Row>
            {data.map((x) => (
              <Card
                key={x.id}
                headStyle={{
                  backgroundColor: CARD_COLOR_ACTIVE,
                  border: 0,
                }}
                bodyStyle={{
                  backgroundColor: 'rgba(255, 120, 100, 0.4)',
                  border: 1,
                }}
                style={{
                  backgroundColor: 'rgba(255, 255, 255, 0.0)',
                  border: 2,
                  margin: 10,
                }}
                extra={
                  <>
                    <Avatar
                      size="large"
                      shape="circle"
                      src={<Image src={x.avatar_url} style={{ width: 40 }} />}
                    />
                  </>
                }
                hoverable={true}
                color="#d2d2d2"
              >
                <Button
                  type="primary"
                  icon={<InfoCircleTwoTone />}
                  size="middle"
                  onClick={(e) => info(x)}
                />
              </Card>
            ))}
          </Row>
        </Wrapper>
      </header>
    </div>
  );
}
function info(x: any) {
  Modal.info({
    title: 'More Info',
    content: (
      <div>
        <Image width={200} src={x.avatar_url} />
        <p>login : {x.login}</p>
        <p>type : {x.type}</p>
        <a href={x.html_url} target="_blank">
          <img
            src="/img/github.png"
            alt="HTML tutorial"
            style={{ width: 30, height: 30 }}
          />
          :{x.html_url}
        </a>
      </div>
    ),
    onOk() {},
  });
}
const Wrapper = styled.div`
  display: flex;
  justify-content: space-between;
  margin: 30px;
  background: linear-gradient(to bottom, transparent, gray);
`;
export default App;
